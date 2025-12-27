using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio
{
    public class Asistencia
    {
        public static List<Datos.busqAsistencia_Result> listarAsistencias(string personal,
            DateTime fecIni, DateTime fecFin)
        {
            using(Datos.carwashEntities db = new Datos.carwashEntities())
            {
                return db.busqAsistencia(personal,fecIni,fecFin).ToList();
            }
        }

        public static string registrarEntrada(short id_Trab)
        {
            try
            {
                using (Datos.carwashEntities db = new Datos.carwashEntities())
                {
                    using (var dbContextTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {

                            Datos.asistencia asistencia = new Datos.asistencia
                            {
                                id_Trabajador = id_Trab,
                                fecha = DateTime.Today,
                                hora_entrada = DateTime.Now.TimeOfDay
                            };
                            db.asistencia.Add(asistencia);
                            db.SaveChanges();
                            dbContextTransaction.Commit();
                            return "Se agrego su asistencia y hora de entrada";
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            return ex.Message;
                        }

                    }
                }
            }
            catch (Exception ex) { return ex.Message; }
        }

        public static string registrarSalida(int id_asistencia)
        {
            try
            {
                using (Datos.carwashEntities db = new Datos.carwashEntities())
                {
                    using (var dbContextTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {

                            Datos.asistencia asistencia = (from q in db.asistencia
                                                     where
                                                     q.id == id_asistencia
                                                     select q).First();

                            asistencia.hora_salida = DateTime.Now.TimeOfDay;
                            db.SaveChanges();
                            dbContextTransaction.Commit();
                            return "Se agrego su hora de salida";
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            return ex.Message;
                        }

                    }
                }
            }
            catch (Exception ex) { return ex.Message; }
        }

        public static string eliminarAsist(int id_asistencia)
        {
            try
            {
                using (Datos.carwashEntities db = new Datos.carwashEntities())
                {
                    using (var dbContextTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {

                            Datos.asistencia asistencia = (from q in db.asistencia
                                                           where
                                   q.id == id_asistencia
                                                           select q).First();
                            db.asistencia.Remove(asistencia);
                            db.SaveChanges();
                            dbContextTransaction.Commit();
                            return "Se elimino la asistencia";
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            return "Error " + ex.Message;
                        }

                    }
                }
            }
            catch (Exception ex) { return ex.Message; }
        }

        public static string actAsist(int id_asistencia,short id_trab,DateTime fecha,
            TimeSpan hora_entrada,TimeSpan hora_salida)
        {
            try
            {
                using (Datos.carwashEntities db = new Datos.carwashEntities())
                {
                    using (var dbContextTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {

                            Datos.asistencia asistencia = (from q in db.asistencia
                                                           where
                                                           q.id == id_asistencia
                                                           select q).First();
                            asistencia.id_Trabajador = id_trab;
                            asistencia.fecha = fecha;
                            asistencia.hora_entrada = hora_entrada;
                            asistencia.hora_salida = hora_salida;
                            db.SaveChanges();
                            dbContextTransaction.Commit();
                            return "Se ha actualizado la asistencia";
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            return ex.Message;
                        }

                    }
                }
            }
            catch (Exception ex) { return ex.Message; }
        }
    }
}
