using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoVO;
using ProjetoDAL.Banco;
using System.Data;

namespace ProjetoDAL
{
    public class TMenuBLL
    {
        #region [ Inserir ]

        public int Inserir(TMenuVO tmenuvo)
        {
            var banco = new SINAF_WebEntities();

            var query = new TMenu
            {
                  IDMenu = tmenuvo.IDMenu,
 
                  Descricao = tmenuvo.Descricao,
 
                  IDMenuPai = tmenuvo.IDMenuPai,
 
                  Mobile = tmenuvo.Mobile,
 
                  Url = tmenuvo.Url,
 
                  Ordenacao = tmenuvo.Ordenacao,
            };

            banco.AddToTMenu(query);
            banco.SaveChanges();

            tmenuvo.IDMenu = query.IDMenu;

            return query.IDMenu;
        }

        #endregion

        #region [ Alterar ]

        public void Alterar(TMenuVO tmenuvo)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TMenu
                         where registro.IDMenu.Equals(tmenuvo.IDMenu)
                         select registro).First();

              query.IDMenu = tmenuvo.IDMenu;
 
              query.Descricao = tmenuvo.Descricao;
 
              query.IDMenuPai = tmenuvo.IDMenuPai;
 
              query.Mobile = tmenuvo.Mobile;
 
              query.Url = tmenuvo.Url;
 
              query.Ordenacao = tmenuvo.Ordenacao;
             
            banco.SaveChanges();

        }

        #endregion

        #region [ Excluir ]

        public void Excluir(int IDMenu)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TMenu where registro.IDMenu == IDMenu select registro).First();

            banco.DeleteObject(query);
            banco.SaveChanges();
        }

        #endregion

        #region [ Obter ]

        public TMenuVO Obter(int IDMenu)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TMenu
                         where registro.IDMenu == IDMenu
                         select new TMenuVO
                         {
                            IDMenu = registro.IDMenu,
 
                            Descricao = registro.Descricao,
 
                            IDMenuPai = registro.IDMenuPai,
 
                            Mobile = registro.Mobile,
 
                            Url = registro.Url,
 
                            Ordenacao = registro.Ordenacao,
 
                         });

            return query.FirstOrDefault();
        }

        #endregion
                
        #region [ Listar ]

        public IQueryable<TMenuVO> Listar(TMenuVO filtro)
        {
            var banco = new SINAF_WebEntities();

            var query = (from registro in banco.TMenu
                         select new TMenuVO
                         {
                            IDMenu = registro.IDMenu,
 
                            Descricao = registro.Descricao,
 
                            IDMenuPai = registro.IDMenuPai,
 
                            Mobile = registro.Mobile,
 
                            Url = registro.Url,
 
                            Ordenacao = registro.Ordenacao,
 
                         }).AsQueryable();

       
          if(!string.IsNullOrEmpty(filtro.Descricao))
              query = query.Where(registro => registro.Descricao.Contains(filtro.Descricao));
 
          if(filtro.IDMenuPai.HasValue)
              query = query.Where(registro => registro.IDMenuPai == filtro.IDMenuPai.Value );
 
          if(filtro.Mobile.HasValue)
              query = query.Where(registro => registro.Mobile == filtro.Mobile.Value);
 
          if(!string.IsNullOrEmpty(filtro.Url))
              query = query.Where(registro => registro.Url.Contains(filtro.Url));
 
          if(filtro.Ordenacao > 0)
              query = query.Where(registro => registro.Ordenacao == filtro.Ordenacao );
 
            return query;
        }

        #endregion

        #region [ ListarTodos ]

        public static Dictionary<int, string> ListarTodos()
        {
            using (var banco = new SINAF_WebEntities())
            {
                var query = (from menu in banco.TMenu
                             orderby menu.Descricao
                             select new
                             {
                                 menu.IDMenu,
                                 menu.Descricao
                             });

                return query.ToDictionary(menu => menu.IDMenu, menu => menu.Descricao);
            }
        }

        #endregion

        #region [ ListarMenuUsuarioXML ]

        public static string ListarMenuUsuarioXML(int codigoUsuario, bool indicadorMobile)
        {
            const string tableName = "Menu";

            var table = ListarMenuUsuarioDataTable(codigoUsuario, indicadorMobile);

            var dataSet = new DataSet();
            dataSet.Tables.Add(table);
            dataSet.Tables[0].TableName = tableName;
            dataSet.DataSetName = "Menus";

            var relation = new DataRelation
            (
                "ParentChild",
                dataSet.Tables[tableName].Columns["IDMenu"],
                dataSet.Tables[tableName].Columns["IDMenuPai"],
                true
            );

            relation.Nested = true;
            dataSet.Relations.Add(relation);

            return dataSet.GetXml();
        }

        #endregion

        #region [ ListarMenuSistemaXML ]

        public static string ListarMenuSistemaXML()
        {
            const string tableName = "Menu";

            var table = ListarMenusSistemaDataTable();

            table = table.DefaultView.ToTable(true,
                                              "IDMenu",
                                              "Descricao",
                                              "IDMenuPai",
                                              "Mobile",
                                              "Url",
                                              "Ordenacao");



            var ds = new DataSet();
            ds.Tables.Add(table);
            ds.Tables[0].TableName = tableName;
            ds.DataSetName = "Menus";

            var relation = new DataRelation
            (
                "ParentChild",
                ds.Tables[tableName].Columns["IDMenu"],
                ds.Tables[tableName].Columns["IDMenuPai"],
                true
            );

            relation.Nested = true;
            ds.Relations.Add(relation);

            return ds.GetXml();
        }

        #endregion

        #region [ - CarregarMenuPai ]

        private static IEnumerable<TMenuVO> CarregarMenuPai(IEnumerable<TMenuVO> menuFilhas)
        {
            List<TMenuVO> result;

            using (var banco = new SINAF_WebEntities())
            {
                var codigosMenuPai = (from codFilhas in menuFilhas where codFilhas.IDMenuPai != null select codFilhas.IDMenuPai).Distinct().ToList();
                var codigosMenu = (from codigos in menuFilhas select codigos.IDMenu).Distinct().ToList();

                List<TMenuVO> query = (from menu in banco.TMenu
                                      select new TMenuVO
                                      {
                                          IDMenu = menu.IDMenu,
                                          Descricao = menu.Descricao,
                                          IDMenuPai = menu.IDMenuPai,
                                          Mobile = menu.Mobile,
                                          Url = menu.Url,
                                          Ordenacao = menu.Ordenacao
                                      }).ToList();

                result = (from menu in query
                          where codigosMenuPai.Any(codigo => codigo == menu.IDMenu)
                          && !codigosMenu.Any(codigo => codigo == menu.IDMenu)
                          select new TMenuVO
                          {
                              IDMenu = menu.IDMenu,
                              Descricao = menu.Descricao,
                              IDMenuPai = menu.IDMenuPai,
                              Mobile = menu.Mobile,
                              Url = menu.Url,
                              Ordenacao = menu.Ordenacao
                          }).ToList();

            }

            return result.Count > 0 ? menuFilhas.Union(CarregarMenuPai(result)).Distinct().ToList() : menuFilhas.ToList();
        }

        #endregion

        #region [ - ListarMenuUsuarioDataTable ]

        private static DataTable ListarMenuUsuarioDataTable(int codigoUsuario, bool indicadorMobile)
        {
            using (var banco = new SINAF_WebEntities())
            {
                DateTime data = DateTime.Now.Date;

                var query = (from menu in banco.TMenu
                             join menuPerfil in banco.TMenuPerfil on menu.IDMenu equals menuPerfil.TMenu.IDMenu
                             join perfil in banco.TPerfil on menuPerfil.TPerfil.IDPerfil equals perfil.IDPerfil
                             join usuario in banco.TUsuario on perfil.IDPerfil equals usuario.TPerfil.IDPerfil
                             where ((usuario.IDUsuario == codigoUsuario))
                             select new TMenuVO
                             {
                                 IDMenu = menu.IDMenu,
                                 Descricao = menu.Descricao,
                                 IDMenuPai = menu.IDMenuPai,
                                 Mobile = menu.Mobile,
                                 Url = menu.Url,
                                 Ordenacao = menu.Ordenacao
                             });



                var listaMenus = CarregarMenuPai(query.Distinct().ToList()).ToList();

                listaMenus = (from menu in listaMenus
                              group menu by new
                              {
                                  menu.IDMenu,
                                  menu.Descricao,
                                  menu.IDMenuPai,
                                  menu.Mobile,
                                  menu.Url,
                                  menu.Ordenacao
                              }
                                  into grp
                                  select new TMenuVO
                                  {
                                      IDMenu = grp.Key.IDMenu,
                                      Descricao = grp.Key.Descricao,
                                      IDMenuPai = grp.Key.IDMenuPai,
                                      Mobile = grp.Key.Mobile,
                                      Url = grp.Key.Url,
                                      Ordenacao = grp.Key.Ordenacao
                                  }).ToList();


                return ConverterListaMenusParaDataTable(listaMenus);
            }
        }

        #endregion

        #region [ - ListarMenusSistemaDataTable ]

        private static DataTable ListarMenusSistemaDataTable()
        {
            using (var banco = new SINAF_WebEntities())
            {
                var query = (from menu in banco.TMenu
                             select new TMenuVO
                             {
                                 IDMenu = menu.IDMenu,
                                 Descricao = menu.Descricao,
                                 IDMenuPai = menu.IDMenuPai,
                                 Mobile = menu.Mobile,
                                 Url = menu.Url,
                                 Ordenacao = menu.Ordenacao
                             }).Distinct().ToList();

                var listaMenus = CarregarMenuPai(query);

                return ConverterListaMenusParaDataTable(listaMenus);
            }
        }

        #endregion

        #region [ - ConverterListaMenusParaDataTable ]

        private static DataTable ConverterListaMenusParaDataTable(IEnumerable<TMenuVO> menu)
        {
            var table = new DataTable();
            table.Columns.Add(new DataColumn("IDMenu", typeof(Int32)));
            table.Columns.Add(new DataColumn("Descricao", typeof(String)));
            table.Columns.Add(new DataColumn("IDMenuPai") { AllowDBNull = true, DataType = typeof(Int32), DefaultValue = DBNull.Value });
            table.Columns.Add(new DataColumn("Mobile") { AllowDBNull = true, DataType = typeof(bool), DefaultValue = DBNull.Value });
            table.Columns.Add(new DataColumn("Url", typeof(String)));
            table.Columns.Add(new DataColumn("Ordenacao", typeof(Int32)));

            foreach (TMenuVO item in menu)
            {
                var row = table.NewRow();

                row["IDMenu"] = item.IDMenu;
                row["Descricao"] = item.Descricao;
                row["IDMenuPai"] = item.IDMenuPai ?? (object)DBNull.Value;
                row["Mobile"] = item.Mobile ?? (object)DBNull.Value;
                row["Url"] = item.Url;
                row["Ordenacao"] = item.Ordenacao;

                table.Rows.Add(row);
            }

            DataView dataView = table.DefaultView;
            dataView.Sort = "Ordenacao, Descricao ASC";
            table = dataView.ToTable();

            return table;
        }

        #endregion
    }
}
