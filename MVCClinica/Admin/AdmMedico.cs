using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using MVCClinica.Models;
using MVCClinica.Data;

namespace MVCClinica.Admin
{
    static public class AdmMedico
    {
        static ClinicaDbContext context = new ClinicaDbContext();

        public static List<Medico> Listar()
        {
            return context.Medicos.ToList();
        }

        public static void Insertar(Medico medico)
        {
            context.Medicos.Add(medico);
            context.SaveChanges();
            
        }

        public static Medico TraerPorId(int id)
        {
            Medico medico = context.Medicos.Find(id);
            context.Entry(medico).State = EntityState.Detached;
            return medico;
        }

        public static void Eliminar(Medico medico)
        {
            if (!context.Medicos.Local.Contains(medico)) { context.Medicos.Attach(medico); }
            context.Medicos.Remove(medico);
            context.SaveChanges();
        }

        public static void Editar(Medico medico)
        {
            context.Medicos.Attach(medico);
            context.Entry(medico).State = EntityState.Modified;
            context.SaveChanges();
        }

        public static List<Medico> TraerPorEspecialidad(string especialidad)
        {
            var medicos = (
                from m in context.Medicos
                where m.Especialidad == especialidad
                select m
                ).ToList();
            return medicos;
        }
    }
}