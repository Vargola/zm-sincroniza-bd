using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zmSBD
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				DirectoryInfo current = new DirectoryInfo(Directory.GetCurrentDirectory());
				foreach (FileInfo fi in current.GetFiles("*.udl"))
				{
					cmbUDL1.Items.Add(fi.Name);
					cmbUDL2.Items.Add(fi.Name);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void cmbUDL1_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				TextBox[] txts = { txtSource1, txtCatalog1, txtUser1, txtPassword1 };
				getDataFromUDL(cmbUDL1, txts);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void cmbUDL2_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				TextBox[] txts = { txtSource2, txtCatalog2, txtUser2, txtPassword2 };
				getDataFromUDL(cmbUDL2, txts);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			rtbResult.Copy();
		}

		private void selecionarTudoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			rtbResult.SelectAll();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			rtbResult.Cursor = Cursors.WaitCursor;
			progressBar1.Visible = true;
			progressBar1.Minimum = 0;
			try
			{
				string db1 = "" +
					@"Password=" + txtPassword1.Text.Trim() +
					";User ID=" + txtUser1.Text.Trim() +
					";Initial Catalog=" + txtCatalog1.Text.Trim() +
					";Data Source=" + txtSource1.Text.Trim();

				string db2 = "" +
					@"Password=" + txtPassword2.Text.Trim() +
					";User ID=" + txtUser2.Text.Trim() +
					";Initial Catalog=" + txtCatalog2.Text.Trim() +
					";Data Source=" + txtSource2.Text.Trim();

				rtbResult.Clear();
				Application.DoEvents();

				SqlConnection conn1 = new SqlConnection(db1);
				conn1.Open();

				SqlConnection conn2 = new SqlConnection(db2);
				conn2.Open();

				// Tabelas, campos e índices.
				DataTable tables1 = conn1.GetSchema("Tables");
				DataTable tables2 = conn2.GetSchema("Tables");

				DataTable cols1 = conn1.GetSchema("Columns");
				DataTable cols2 = conn2.GetSchema("Columns");

				DataTable indexes1 = conn1.GetSchema("Indexes");
				DataTable indexes2 = conn2.GetSchema("Indexes");

				DataTable indexesCols1 = conn1.GetSchema("IndexColumns");
				DataTable indexesCols2 = conn2.GetSchema("IndexColumns");

				int c = 0;
				DataRow[] dr1 = tables1.Select("table_type = 'BASE TABLE'");
				progressBar1.Maximum = dr1.Length;
				progressBar1.Value = 0;
				Application.DoEvents();

				if (chkNovos.Checked)
				{
                    if (!chkListagem.Checked)
                    {
                        rtbResult.AppendText("\n-- >>>> TABELAS, CAMPOS E ÍNDICES A SEREM CRIADOS OU CAMPOS A SEREM MODIFICADOS <<<<\n");
                        rtbResult.AppendText("\n-- Database 1: " + tables1.Select("table_type = 'BASE TABLE'").Length + " tabela(s).");
                        rtbResult.AppendText("\n-- Database 2: " + tables2.Select("table_type = 'BASE TABLE'").Length + " tabela(s).\n");
                        Application.DoEvents();
                    }

					foreach (DataRow table in dr1)
					{
						int i;
						string tableName = table["table_name"].ToString();
						string tableSchema = table["table_schema"].ToString().ToLower();

						DataRow[] colsTable1 = cols1.Select("table_name = '" + tableName + "'", "ordinal_position");
						DataRow[] indexesTable1 = indexes1.Select("table_name = '" + tableName + "'");

						if (tables2.Select("table_name = '" + tableName + "'").Length < 1)
						{
							c++;

                            if (chkListagem.Checked)
                            {
                                rtbResult.AppendText("\nTabela inexistente;" + tableName.ToLower());
                            }
                            else
                            {
                                rtbResult.AppendText("\ncreate table dbo." + tableName.ToLower() + " (");
                                i = 0;
                                foreach (DataRow col in colsTable1)
                                {
                                    i++;
                                    string defaultValue = col["column_default"].ToString();
                                    rtbResult.AppendText("\n" +
                                        col["column_name"].ToString().ToLower() + " " + columnDataType(col) + " " +
                                        (col["is_nullable"].ToString().ToLower() == "yes" ? "NULL" : "NOT NULL") + " " +
                                        (defaultValue == "" ? "" : "DEFAULT (" + defaultValue + ")") +
                                        (i < colsTable1.Length ? "," : ""));
                                }
                                rtbResult.AppendText("\n)\ngo\n");
                            }

                            if (!chkListagem.Checked)
                            {
                                foreach (DataRow index in indexesTable1)
                                {
                                    string indexName = index["constraint_name"].ToString();

                                    if (indexName.ToUpper().StartsWith("PK"))
                                    {
                                        rtbResult.AppendText("\nalter table dbo." + tableName.ToLower());
                                        rtbResult.AppendText("\nadd constraint " + indexName + " PRIMARY KEY (");
                                        DataRow[] indexCols = indexesCols1.Select("constraint_name = '" + indexName + "'", "ordinal_position");
                                        i = 0;
                                        foreach (DataRow indexCol in indexCols)
                                        {
                                            i++;
                                            rtbResult.AppendText("\n" + indexCol["column_name"] + (i < indexCols.Length ? "," : ""));
                                        }
                                        rtbResult.AppendText("\n)\ngo\n");
                                    }
                                    else
                                    {
                                        rtbResult.AppendText("\ncreate index " + indexName + " on dbo." + tableName.ToLower() + " (");
                                        DataRow[] indexCols = indexesCols1.Select("constraint_name = '" + indexName + "'", "ordinal_position");
                                        i = 0;
                                        foreach (DataRow indexCol in indexCols)
                                        {
                                            i++;
                                            rtbResult.AppendText("\n" + indexCol["column_name"] + (i < indexCols.Length ? "," : ""));
                                        }
                                        rtbResult.AppendText("\n)\ngo\n");
                                    }
                                }
                            }
						}
						else
						{
							foreach (DataRow col in colsTable1)
							{
								string colName = col["column_name"].ToString();

                                var col2 = cols2.Select("table_name = '" + tableName + "' and column_name = '" + colName + "'");

                                if (col2.Length < 1)
                                {
                                    if (chkListagem.Checked)
                                    {
                                        rtbResult.AppendText("\nColuna inexistente;" + tableName.ToLower() + ";" + col["column_name"].ToString().ToLower());
                                    }
                                    else
                                    {
                                        string defaultValue = col["column_default"].ToString();
                                        rtbResult.AppendText("\n" +
                                            "alter table " + tableSchema + "." + tableName.ToLower() + " add " +
                                            col["column_name"].ToString().ToLower() + " " + columnDataType(col) + " " +
                                            (col["is_nullable"].ToString().ToLower() == "yes" ? "NULL" : "NOT NULL") + " " +
                                            (defaultValue == "" ? "" : "DEFAULT (" + defaultValue + ")"));
                                        rtbResult.AppendText("\ngo\n");
                                    }
                                }
                                else
                                {
                                    if (columnDataType(col) != columnDataType(col2[0]))
                                    {
                                        if (chkListagem.Checked)
                                        {
                                            rtbResult.AppendText(
                                                "\nColuna mudou tipo;" + tableName.ToLower() + ";" + col["column_name"].ToString().ToLower() +
                                                ";" + columnDataType(col) + ";" + columnDataType(col2[0]));
                                        }
                                        else
                                        {
                                            string defaultValue = col["column_default"].ToString();
                                            rtbResult.AppendText("\n" +
                                                "alter table " + tableSchema + "." + tableName.ToLower() + " alter column " +
                                                col["column_name"].ToString().ToLower() + " " + columnDataType(col) + " " +
                                                (col["is_nullable"].ToString().ToLower() == "yes" ? "NULL" : "NOT NULL") + " " +
                                                (defaultValue == "" ? "" : "DEFAULT (" + defaultValue + ")"));
                                            rtbResult.AppendText("\ngo\n");
                                        }
                                    }
                                }
							}

							foreach (DataRow index in indexesTable1)
							{
								string indexName = index["constraint_name"].ToString();

                                if (indexes2.Select("table_name = '" + tableName + "' and constraint_name = '" + indexName + "'").Length < 1)
                                {
                                    if (chkListagem.Checked)
                                    {
                                        rtbResult.AppendText("\nIndice inexistente;" + tableName + ";;;;" + indexName);
                                    }
                                    else
                                    {
                                        if (indexName.ToUpper().StartsWith("PK"))
                                        {
                                            if (indexes2.Select("table_name = '" + tableName + "' and constraint_name like 'PK%'").Length < 1)
                                            {
                                                rtbResult.AppendText("\nalter table " + tableSchema + "." + tableName.ToLower());
                                                rtbResult.AppendText("\nadd constraint " + indexName + " PRIMARY KEY (");
                                                DataRow[] indexCols = indexesCols1.Select("constraint_name = '" + indexName + "'", "ordinal_position");
                                                i = 0;
                                                foreach (DataRow indexCol in indexCols)
                                                {
                                                    i++;
                                                    rtbResult.AppendText("\n" + indexCol["column_name"] + (i < indexCols.Length ? "," : ""));
                                                }
                                                rtbResult.AppendText("\n)\ngo\n");
                                            }
                                        }
                                        else
                                        {
                                            rtbResult.AppendText("\ncreate index " + indexName + " on " + tableSchema + "." + tableName.ToLower() + " (");
                                            DataRow[] indexCols = indexesCols1.Select("constraint_name = '" + indexName + "'", "ordinal_position");
                                            i = 0;
                                            foreach (DataRow indexCol in indexCols)
                                            {
                                                i++;
                                                rtbResult.AppendText("\n" + indexCol["column_name"] + (i < indexCols.Length ? "," : ""));
                                            }
                                            rtbResult.AppendText("\n)\ngo\n");
                                        }
                                    }
                                }
                                else
                                {
                                    DataRow[] indexCols1 = indexesCols1.Select("constraint_name = '" + indexName + "'", "ordinal_position");
                                    var colunas1 = "";
                                    foreach (DataRow indexCol1 in indexCols1)
                                    {
                                        colunas1 += "-" + indexCol1["column_name"].ToString().Trim();
                                    }

                                    DataRow[] indexCols2 = indexesCols2.Select("constraint_name = '" + indexName + "'", "ordinal_position");
                                    var colunas2 = "";
                                    foreach (DataRow indexCol2 in indexCols2)
                                    {
                                        colunas2 += "-" + indexCol2["column_name"].ToString().Trim();
                                    }

                                    if(!colunas1.Equals(colunas2))
                                    {
                                        if (chkListagem.Checked)
                                        {
                                            rtbResult.AppendText(
                                                "\nIndice com colunas diferentes;" + tableName + ";;;;" + indexName +
                                                ";" + colunas1.Substring(1) + ";" + colunas2.Substring(1));
                                        }
                                    }
                                }
							}
						}
						progressBar1.Value += 1;
						Application.DoEvents();
					}

                    if (!chkListagem.Checked)
                    {
                        if (c > 0)
                        {
                            rtbResult.AppendText("\n-- >>>> Quantidade de tabelas a serem criadas no ambiente 2: " + c + ".\n\n");
                        }
                        else
                        {
                            rtbResult.AppendText("\n-- >>>> Nenhuma tabela precisa ser criada no ambiente 2.\n\n");
                        }
                    }
				}

				if (chkExcluidos.Checked)
				{
                    if (!chkListagem.Checked)
                    {
                        rtbResult.AppendText("\n-- >>>> TABELAS, CAMPOS E ÍNDICES A SEREM EXCLUÍDOS <<<<\n");
                        rtbResult.AppendText("\n-- Database 1: " + tables1.Select("table_type = 'BASE TABLE'").Length + " tabela(s).");
                        rtbResult.AppendText("\n-- Database 2: " + tables2.Select("table_type = 'BASE TABLE'").Length + " tabela(s).\n");
                    }

					c = 0;
					DataRow[] dr2 = tables2.Select("table_type = 'BASE TABLE'");
					progressBar1.Maximum = tables2.Rows.Count;
					progressBar1.Value = 0;
					Application.DoEvents();

					foreach (DataRow table in dr2)
					{
						string tableName = table["table_name"].ToString();
						string tableSchema = table["table_schema"].ToString().ToLower();

						DataRow[] colsTable2 = cols2.Select("table_name = '" + tableName + "'", "ordinal_position");
						DataRow[] indexesTable2 = indexes2.Select("table_name = '" + tableName + "'");

						if (tables1.Select("table_name = '" + tableName + "'").Length < 1)
						{
							c++;
                            if (chkListagem.Checked)
                            {
                                rtbResult.AppendText("\nTabela nova;" + tableName.ToLower());
                            }
                            else
                            {
                                rtbResult.AppendText("\n/*\ndrop table " + tableSchema + "." + tableName.ToLower());
                                rtbResult.AppendText("\ngo\n*/\n");
                            }
						}

						else
						{
							foreach (DataRow col in colsTable2)
							{
								string colName = col["column_name"].ToString();

								if (cols1.Select("table_name = '" + tableName + "' and column_name = '" + colName + "'").Length < 1)
								{
                                    if (chkListagem.Checked)
                                    {
                                        rtbResult.AppendText("\nColuna nova;" + tableName.ToLower() + ";" + col["column_name"].ToString().ToLower());
                                    }
                                    else
                                    {
                                        rtbResult.AppendText("\n/*\n" +
                                            "alter table " + tableSchema + "." + tableName.ToLower() + "\ndrop column " +
                                            col["column_name"].ToString().ToLower());
                                        rtbResult.AppendText("\ngo\n*/\n");
                                    }
								}
							}

							foreach (DataRow index in indexesTable2)
							{
								string indexName = index["constraint_name"].ToString();

								if (indexes1.Select("table_name = '" + tableName + "' and constraint_name = '" + indexName + "'").Length < 1)
								{
									if (indexName.ToUpper().StartsWith("PK"))
									{
										DataRow[] pkName1 = indexes1.Select("table_name = '" + tableName + "' and constraint_name like 'PK%'");
										if (pkName1.Length == 1)
										{
                                            if (chkListagem.Checked)
                                            {
                                                rtbResult.AppendText("\nIndice renomeado;" + tableName + ";;;;" + indexName + ";" + pkName1[0]["constraint_name"].ToString());
                                            }
                                            else
                                            {
                                                rtbResult.AppendText("\nexec sp_rename N'" + tableSchema + "." + tableName + "." + indexName + "', N'" + pkName1[0]["constraint_name"].ToString() + "', N'INDEX'");
                                                rtbResult.AppendText("\ngo\n");
                                            }
										}
									}
									else
									{
                                        if (chkListagem.Checked)
                                        {
                                            rtbResult.AppendText("\nIndice novo;" + tableName.ToLower() + ";;;;" + indexName);
                                        }
                                        else
                                        {
                                            rtbResult.AppendText("\n/*\ndrop index " + tableSchema + "." + tableName.ToLower() + "." + indexName);
                                            rtbResult.AppendText("\ngo\n*/\n");
                                        }
									}
								}
							}
						}
						progressBar1.Value += 1;
						Application.DoEvents();
					}

                    if (!chkListagem.Checked)
                    {
                        if (c > 0)
                        {
                            rtbResult.AppendText("\n-- >>>> Quantidade de tabelas a serem excluídas no ambiente 2: " + c + ".\n\n");
                        }
                        else
                        {
                            rtbResult.AppendText("\n-- >>>> Nenhuma tabela precisa ser excluída no ambiente 2.\n\n");
                        }
                    }
				}

				// Views.
				if (chkViews.Checked)
				{
					rtbResult.AppendText("\n-- >>>> VIEWS <<<<\n");

					DataTable views1 = conn1.GetSchema("Views");
					DataTable views2 = conn2.GetSchema("Views");

					rtbResult.AppendText("\n-- Database 1: " + views1.Rows.Count + " view(s).");
					rtbResult.AppendText("\n-- Database 2: " + views2.Rows.Count + " view(s).\n");

					cols1 = conn1.GetSchema("ViewColumns");
					cols2 = conn2.GetSchema("ViewColumns");

					progressBar1.Maximum = views1.Rows.Count + views2.Rows.Count;
					progressBar1.Value = 0;
					Application.DoEvents();
					foreach (DataRow view in views1.Rows)
					{
						string viewName = view["table_name"].ToString();
						DataRow[] colsTable1 = cols1.Select("view_name = '" + viewName + "'");
						if (views2.Select("table_name = '" + viewName + "'").Length < 1)
						{
							rtbResult.AppendText("\n-- View não existe no ambiente 2: " + viewName.ToLower());
							rtbResult.AppendText(sqlHelpText(viewName, conn1));
						}
						else
						{
							if (!isEqualContentRoutine(viewName, conn1, conn2))
							{
								rtbResult.AppendText("\n-- Conteúdo da view está diferente no ambiente 2: " + viewName.ToLower());
								rtbResult.AppendText(sqlHelpText(viewName, conn1, true, "view"));
							}
							else
							{
								foreach (DataRow col in colsTable1)
								{
									string colName = col["column_name"].ToString();
									if (cols2.Select("view_name = '" + viewName + "' and column_name = '" + colName + "'").Length < 1)
									{
										rtbResult.AppendText("\n-- Coluna (view) não existe no ambiente 2: " + viewName.ToLower() + "." + colName.ToLower());
										rtbResult.AppendText(sqlHelpText(viewName, conn1, true, "view"));
										break;
									}
								}
							}
						}
						progressBar1.Value += 1;
						Application.DoEvents();
					}

					foreach (DataRow view in views2.Rows)
					{
						string viewName = view["table_name"].ToString();
						string viewSchema = view["table_schema"].ToString();
						DataRow[] colsTable2 = cols2.Select("view_name = '" + viewName + "'");
						if (views1.Select("table_name = '" + viewName + "'").Length < 1)
						{
							rtbResult.AppendText("\n-- View não existe no ambiente 1: " + viewName.ToLower() + "\n");
							rtbResult.AppendText("\n/*\ndrop view " + viewSchema + "." + viewName.ToLower());
							rtbResult.AppendText("\ngo\n*/\n");
						}
						//else
						//{
						//    foreach (DataRow col in colsTable2)
						//    {
						//        string colName = col["column_name"].ToString();
						//        if (cols1.Select("table_name = '" + viewName + "' and column_name = '" + colName + "'").Length < 1)
						//        {
						//            rtbResult.AppendText("\n-- Coluna (view) não existe no ambiente 1: " + viewName.ToLower() + "." + colName.ToLower() + "\n");
						//            rtbResult.AppendText(sqlHelpText(viewName, conn1, true));
						//            break;
						//        }
						//    }
						//}
						progressBar1.Value += 1;
						Application.DoEvents();
					}
				}

				// Procedures.
				if (chkProcs.Checked)
				{
					rtbResult.AppendText("\n-- >>>> PROCS & FUNCTIONS <<<<\n");

					DataTable routines1 = conn1.GetSchema("Procedures");
					DataTable routines2 = conn2.GetSchema("Procedures");

					rtbResult.AppendText("\n-- Database 1: " + routines1.Rows.Count + " rotina(s).");
					rtbResult.AppendText("\n-- Database 2: " + routines2.Rows.Count + " rotina(s).\n");

					DataTable params1 = conn1.GetSchema("ProcedureParameters");
					DataTable params2 = conn2.GetSchema("ProcedureParameters");

					progressBar1.Maximum = routines1.Rows.Count + routines2.Rows.Count;
					progressBar1.Value = 0;
					Application.DoEvents();
					foreach (DataRow routine in routines1.Rows)
					{
						string routineName = routine["routine_name"].ToString();

						if (!routineName.Trim().ToLower().StartsWith("dt_"))
						{
							string routineType = routine["routine_type"].ToString();
							DataRow[] paramsTable1 = params1.Select("specific_name = '" + routineName + "'");
							if (routines2.Select("routine_name = '" + routineName + "'").Length < 1)
							{
								rtbResult.AppendText("\n-- " + routineType.ToLower() + " não existe no ambiente 2: " + routineName.ToLower());
								rtbResult.AppendText(sqlHelpText(routineName, conn1));
							}
							else
							{
								if (!isEqualContentRoutine(routineName, conn1, conn2))
								{
									rtbResult.AppendText("\n-- Conteúdo da rotina está diferente no ambiente 2: " + routineName.ToLower());
									rtbResult.AppendText(sqlHelpText(routineName, conn1, true, routineType));
								}
								else
								{
									foreach (DataRow param in paramsTable1)
									{
										string paramName = param["parameter_name"].ToString();
										if (params2.Select("specific_name = '" + routineName + "' and parameter_name = '" + paramName + "'").Length < 1)
										{
											rtbResult.AppendText("\n-- Parâmetro não existe no ambiente 2: " + routineName.ToLower() + "." + paramName.ToLower());
											rtbResult.AppendText(sqlHelpText(routineName, conn1, true, routineType));
											break;
										}
									}
								}
							}
						}
						progressBar1.Value += 1;
						Application.DoEvents();
					}

					foreach (DataRow routine in routines2.Rows)
					{
						string routineName = routine["routine_name"].ToString();
						string routineType = routine["routine_type"].ToString();
						string routineSchema = routine["routine_schema"].ToString();
						DataRow[] paramsTable2 = params2.Select("specific_name = '" + routineName + "'");
						if (routines1.Select("routine_name = '" + routineName + "'").Length < 1)
						{
							rtbResult.AppendText("\n-- " + routineType.ToLower() + " não existe no ambiente 1: " + routineName.ToLower() + "\n");
							rtbResult.AppendText("\n/*\ndrop " + routineType.ToLower() + " " + routineSchema + "." + routineName.ToLower());
							rtbResult.AppendText("\ngo\n*/\n");
						}
						//else
						//{
						//    foreach (DataRow param in paramsTable2)
						//    {
						//        string paramName = param["parameter_name"].ToString();
						//        if (params1.Select("specific_name = '" + routineName + "' and parameter_name = '" + paramName + "'").Length < 1)
						//        {
						//            rtbResult.AppendText("\n-- Parâmetro não existe no ambiente 1: " + routineName.ToLower() + "." + paramName.ToLower() + "\n");
						//            rtbResult.AppendText(sqlHelpText(routineName, conn1, true));
						//            break;
						//        }
						//    }
						//}
						progressBar1.Value += 1;
						Application.DoEvents();
					}
				}

				conn1.Close();
				conn2.Close();

				MessageBox.Show("Fim do processo de análise");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				Cursor = Cursors.Default;
				rtbResult.Cursor = Cursors.Default;
				progressBar1.Visible = false;
				progressBar1.Maximum = 0;
				progressBar1.Value = 0;
				Application.DoEvents();
			}
		}

		private void getDataFromUDL(ComboBox cmb, TextBox[] txts)
		{
			FileInfo fi = new FileInfo(cmb.Text);
			StreamReader sr = fi.OpenText();
			string line;
			while ((line = sr.ReadLine()) != null)
			{
				foreach (string s1 in line.Split(';'))
				{
					string[] s2 = s1.Split('=');
					if (s2.Length == 2)
					{
						string field = s2[0].ToString().Trim().ToUpper();
						string value = s2[1].ToString().Trim();
						switch (field)
						{
							case "DATA SOURCE":
								txts[0].Text = value.ToUpper();
								break;
							case "INITIAL CATALOG":
								txts[1].Text = value.ToLower();
								break;
							case "USER ID":
								txts[2].Text = value.ToLower();
								break;
							case "PASSWORD":
								txts[3].Text = value.ToLower();
								break;
						}
					}
				}
			}
		}

		private string columnDataType(DataRow column)
		{
			string dataType = column["data_type"].ToString().ToLower();
			if ((dataType.EndsWith("char")) || (dataType.EndsWith("binary")))
			{
				dataType += "(" + column["character_maximum_length"] + ")";
			}
			else if ((dataType == "decimal") || (dataType == "numeric"))
			{
				dataType += "(" + column["numeric_precision"] + ", " + column["numeric_scale"] + ")";
			}
			return dataType;
		}

		private string sqlHelpText(string routineName, SqlConnection conn)
		{
			return sqlHelpText(routineName, conn, false, "");
		}

		private string sqlHelpText(string routineName, SqlConnection conn, bool isAlter, string routineType)
		{
			string text = "\n-- sp_helptext " + routineName + "\ngo\n";
			bool isComment = false;
			bool isLineComment = false;

			try
			{
				routineType = routineType.ToUpper().Replace("PROCEDURE", "PROC");
				SqlCommand comm = new SqlCommand("sp_helptext " + routineName, conn);
				SqlDataReader reader = comm.ExecuteReader();
				while (reader.Read())
				{
					string s0 = reader[0].ToString();
					string s0aux = s0.Replace('\t', ' ').Trim().ToUpper();
					if (s0aux.StartsWith("/*"))
					{
						isComment = true;
					}
					if (s0aux.EndsWith("*/"))
					{
						isComment = false;
					}
					if (s0aux.StartsWith("--"))
					{
						isLineComment = true;
					}
					else
					{
						isLineComment = false;
					}
					if (!isLineComment && !isComment && isAlter && s0aux.Contains("CREATE " + routineType))
					{
						s0 = s0.ToUpper().Replace("CREATE", "ALTER");
					}
					text += s0; // +"\n";
				}
				reader.Close();
				comm.Dispose();
				text += "\ngo";
			}
			catch (Exception ex)
			{
				text += "\n-- ERROR: " + ex.Message;
			}
			finally
			{
				text += "\n";
			}
			return text;
		}

		private bool isEqualContentRoutine(string routineName, SqlConnection conn1, SqlConnection conn2)
		{
			SqlCommand comm1 = new SqlCommand("sp_help " + routineName, conn1);
			SqlDataReader reader1 = comm1.ExecuteReader();

			SqlCommand comm2 = new SqlCommand("sp_help " + routineName, conn2);
			SqlDataReader reader2 = comm2.ExecuteReader();

			if (reader1.Read() && reader2.Read())
			{
				DateTime dt1 = Convert.ToDateTime(reader1[3]);
				DateTime dt2 = Convert.ToDateTime(reader2[3]);

				// Verifica a data de compilação da rotina.
				if (dt2.CompareTo(dt1) >= 0)
				{
					reader1.Close();
					comm1.Dispose();
					reader2.Close();
					comm2.Dispose();

					return true;
				}
			}

			reader1.Close();
			comm1.Dispose();

			reader2.Close();
			comm2.Dispose();

			comm1 = new SqlCommand("sp_helptext " + routineName, conn1);
			reader1 = comm1.ExecuteReader();

			comm2 = new SqlCommand("sp_helptext " + routineName, conn2);
			reader2 = comm2.ExecuteReader();

			short n = 0;
			while (reader1.Read())
			{
				string s = reader1[0].ToString().Replace('\t', ' ').Trim().ToUpper();
				if ((n == 0) && (s.Contains("CREATE"))) n = 1;
				if ((n == 1) && (s.Contains(routineName.ToUpper()))) break;
			}

			n = 0;
			while (reader2.Read())
			{
				string s = reader2[0].ToString().Replace('\t', ' ').Trim().ToUpper();
				if ((n == 0) && (s.Contains("CREATE"))) n = 1;
				if ((n == 1) && (s.Contains(routineName.ToUpper()))) break;
			}

			while (reader1.Read() && reader2.Read())
			{
				string s1 = reader1[0].ToString().Replace('\t', ' ').Trim().ToUpper();
				string s2 = reader2[0].ToString().Replace('\t', ' ').Trim().ToUpper();

				if ((!s1.Equals("")) && (!s2.Equals("")) && (!s1.Equals(s2)))
				{
					reader1.Close();
					comm1.Dispose();
					reader2.Close();
					comm2.Dispose();

					return false;
				}
			}

			reader1.Close();
			comm1.Dispose();
			reader2.Close();
			comm2.Dispose();

			return true;
		}
	}
}
