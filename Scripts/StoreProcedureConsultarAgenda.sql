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
	 @nombres as varchar(200) = null,
	 @IdAgenda int = null
    )    
    as     
    Begin    
		if @TipoConsulta = 0 begin
			if @Sucursal = 0 begin
				--Consulta Todos
				select id,nombres,apellidos,(nombres + ' ' + apellidos) NombresCompletos,extension,estado,sucursal,direccion,pbx,fax,lineaCelular,lineaCelularAdicional,fechaCreacion,email
				from agenda.AgendaTelefonica
				order by Id;
			end
			else begin
				--Consulta por Sucursal
				select id,nombres,apellidos,(nombres + ' ' + apellidos) NombresCompletos,extension,estado,sucursal,direccion,pbx,fax,lineaCelular,lineaCelularAdicional,fechaCreacion,email
				from agenda.AgendaTelefonica
				where sucursal = @Sucursal
				and estado = 1;
			end
		end
		--Consultar por Id
		if @TipoConsulta = 1 begin
			select id,nombres,apellidos,(nombres + ' ' + apellidos) NombresCompletos,extension,estado,sucursal,direccion,pbx,fax,lineaCelular,lineaCelularAdicional,fechaCreacion,email
			from agenda.AgendaTelefonica
			where id = @IdAgenda;
		end
    End  


/*
exec [Agenda].[ConsultarAgenda]
*/
