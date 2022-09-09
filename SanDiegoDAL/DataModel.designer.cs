﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SanDiegoDAL
{
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Data;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.Linq.Expressions;
    using System.ComponentModel;
    using System;
    using SanDiegoBE;

    public partial class DataModelDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public DataModelDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataModelDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataModelDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataModelDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}


        #region LecturaContador

        [Function(Name = "dbo.SPLecturaContador_Crear")]
        public int LecturaContador_Crear(
            [Parameter(DbType = "varchar(25)")] string NumContador,
            [Parameter(DbType = "datetime")] DateTime? Fecha,
            [Parameter(DbType = "decimal(20, 8)")] decimal? Valor,
            [Parameter(DbType = "varchar(999)")] string Observaciones
            )
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()),
                NumContador,
                Fecha,
                Valor,
                Observaciones
                );
            return ((int)result.ReturnValue);
        }

        [Function(Name = "dbo.SPLecturaContador_Actualizar")]
        public int LecturaContador_Actualizar(
            [Parameter(DbType = "int")] int? IdLectura,
            [Parameter(DbType = "varchar(25)")] string NumContador,
            [Parameter(DbType = "datetime")] DateTime? Fecha,
            [Parameter(DbType = "decimal(20, 8)")] decimal? Valor,
            [Parameter(DbType = "varchar(999)")] string Observaciones
            )
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()),
                IdLectura,
                NumContador,
                Fecha,
                Valor,
                Observaciones
                );
            return ((int)result.ReturnValue);
        }

        [Function(Name = "dbo.SPLecturaContador_Eliminar")]
        public int LecturaContador_Eliminar(
            [Parameter(DbType = "int")] int? IdLectura
            )
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()),
                IdLectura
                );
            return ((int)result.ReturnValue);
        }

        [Function(Name = "dbo.SPLecturaContador_Listar")]
        public ISingleResult<LecturaContadorBE> LecturaContador_Listar(
            [Parameter(DbType = "int")] int? IdLectura
            )
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()),
                IdLectura
                );
            return ((ISingleResult<LecturaContadorBE>)result.ReturnValue);
        }

        #endregion

    }
}
#pragma warning restore 1591
