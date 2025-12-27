using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio
{
    public class Adicional
    {

        public static List<Datos.traerAdicionales> traerAdicionales()
        {
            using (Datos.carwashEntities db = new Datos.carwashEntities())
            {
                return db.traerAdicionales.ToList();
            }
        }

        public static string traerDescAdic(short id_tarAdic)
        {
            using (Datos.carwashEntities db = new Datos.carwashEntities())
            {
                return db.tarifa_adicional.Where(ta => ta.id_TA.Equals(id_tarAdic)).Select(ta => ta.descripcion).First();
            }
        }

        public static bool evitarDupTar(string adicional)
        {
            using (Datos.carwashEntities db = new Datos.carwashEntities())
            {
                var tarifa = db.tarifa_adicional.Where(ta => ta.descripcion == adicional).ToList();
                return tarifa.Any();
            }
        }

        public static decimal traerPrecAdic(short id_ta)
        {
            using(Datos.carwashEntities db = new Datos.carwashEntities())
            {
                return db.tarifa_adicional.Where(ta => ta.id_TA == id_ta).Select(ta => ta.precio).First();
            }
        }
        public static string agregar(string adicional, decimal precio)
        {
            try
            {
                using (Datos.carwashEntities db = new Datos.carwashEntities())
                {
                    using (var dbContextTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {

                            Datos.tarifa_adicional tarifaAdi = new Datos.tarifa_adicional
                            {
                                descripcion = adicional,
                                precio = precio,
                                
                            };
                            db.tarifa_adicional.Add(tarifaAdi);
                            db.SaveChanges();
                            dbContextTransaction.Commit();
                            return "Tarifa registrada correctamente";
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            return "Error " + ex;
                        }

                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static string actualizar(short id_adicional,string adicional, decimal precio)
        {
            try
            {
                using (Datos.carwashEntities db = new Datos.carwashEntities())
                {
                    using (var dbContextTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {

                            Datos.tarifa_adicional tarifaAdi = (from q in db.tarifa_adicional
                                                             where
                                     q.id_TA == id_adicional
                                                             select q).First();
                            tarifaAdi.descripcion = adicional;
                            tarifaAdi.precio = precio;
                            db.SaveChanges();
                            dbContextTransaction.Commit();
                            return "Tarifa actualizada correctamente";
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            return "Error " + ex;
                        }

                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static string eliminar(short id_adiconal)
        {
            try
            {
                using (Datos.carwashEntities db = new Datos.carwashEntities())
                {
                    using (var dbContextTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {

                            Datos.tarifa_adicional tarifaAdi = (from q in db.tarifa_adicional
                                                             where
                                     q.id_TA == id_adiconal
                                                             select q).First();
                            db.tarifa_adicional.Remove(tarifaAdi);
                            db.SaveChanges();
                            dbContextTransaction.Commit();
                            return "Tarifa eliminada correctamente";
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            return "Error " + ex;
                        }

                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
