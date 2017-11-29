USE [TiendaDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployee]    Script Date: 28/11/2017 20:43:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter Procedure [Agenda].[ConsultarAgenda]    
    (    
     @TipoConsulta as int = 0,
	 @Sucursal int = 0,
	 @nombres as varchar(200) = null    
    )    
    as     
    Begin    
		if @TipoConsulta = 0 begin
			if @Sucursal = 0 begin
				--Consulta Todos
				select nombres,apellidos,(nombres + ' ' + apellidos) NombresCompletos,extension,estado,sucursal,direccion,pbx,fax,lineaCelular,lineaCelularAdicional,fechaCreacion
				from agenda.AgendaTelefonica;
			end
			else begin
				--Consulta por Sucursal
				select nombres,apellidos,(nombres + ' ' + apellidos) NombresCompletos,extension,estado,sucursal,direccion,pbx,fax,lineaCelular,lineaCelularAdicional,fechaCreacion
				from agenda.AgendaTelefonica
				where sucursal = @Sucursal;
			end
		end
		--Consultar por nombre
		if @TipoConsulta = 1 begin
			select nombres,apellidos,(nombres + ' ' + apellidos) NombresCompletos,extension,estado,sucursal,direccion,pbx,fax,lineaCelular,lineaCelularAdicional,fechaCreacion
			from agenda.AgendaTelefonica
			where (nombres + ' ' + apellidos) like @nombres;
		end
    End  
