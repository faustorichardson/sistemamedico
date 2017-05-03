
/* Query de consultas citas medicas */
SELECT 
	cita.idcita,
	cita.fechacita,
	cita.cedulapaciente,
	CONCAT(paciente.nombre,' ',paciente.apellido) as paciente,
	doctores.doctores_cedula,
	CONCAT(doctores.doctores_nombre,' ',doctores.doctores_apellido) as doctor,
	departamentos.departamento_descripcion
FROM
	cita
INNER JOIN paciente ON paciente.cedula = cita.cedulapaciente
INNER JOIN doctores ON doctores.doctores_cedula = cita.ceduladoctor
INNER JOIN departamentos ON departamentos.departamento_id = cita.referimiento
	AND fechacita >= '2014-12-10' AND fechacita <= '2014-12-25'
	AND referimiento = 2


SELECT * from licenciasmedicas

select * from casomedico

/* Query de la Sumatorias de los Reportes a Generar */
select 
	rangos.rango_descripcion, count(licenciasmedicas.rango),
	sum(licenciasmedicas.idlicencia) as cantidadtotal
from 
	licenciasmedicas, rangos
where 
	licenciasmedicas.rango = rangos.rango_id
group by
	licenciasmedicas.rango

/* Query de la Sumatorias de los Reportes a Generar POR DEPENDENCIAS */
select 
	dependencias.nomdepart, count(licenciasmedicas.dependencia),
	sum(licenciasmedicas.idlicencia) as cantidadtotal
from 
	licenciasmedicas, dependencias
where 
	licenciasmedicas.dependencia = dependencias.coddepart
group by
	licenciasmedicas.dependencia
order by 
	idlicencia


/* Query de la Sumatorias de los Reportes a Generar SECCION NAVAL */
select 
	seccionaval.nomsec, count(licenciasmedicas.seccionaval) as cantidad,
	sum(licenciasmedicas.idlicencia) as cantidadtotal
from 
	licenciasmedicas, seccionaval
where 
	licenciasmedicas.seccionaval = seccionaval.codsec
group by
	licenciasmedicas.seccionaval
order by
	licenciasmedicas.idlicencia

/* QUERY PARA GENERAR LAS LICENCIAS MEDICAS */
SELECT 
	licenciasmedicas.cedulapaciente, rangos.rango_descripcion as rangopaciente,
	concat(paciente.nombre,' ', paciente.apellido) as nombrepaciente,
	licenciasmedicas.razonlicencia, dependencias.nomdepart, seccionaval.nomsec,
	concat(doctores.doctores_nombre,' ', doctores.doctores_apellido) as nombredoctor,
	rangos.rangoabrev as rangodoctor, especialidades.especialidades_descripcion as doctorespecialidad
FROM 
	licenciasmedicas
INNER JOIN paciente ON paciente.cedula = licenciasmedicas.cedulapaciente
INNER JOIN dependencias ON dependencias.coddepart = licenciasmedicas.dependencia
INNER JOIN seccionaval ON seccionaval.codsec = licenciasmedicas.seccionaval
INNER JOIN doctores ON doctores.doctores_cedula = licenciasmedicas.ceduladoctor
INNER JOIN rangos ON rangos.rango_id = doctores.doctores_rango
INNER JOIN especialidades ON especialidades.especialidades_id = doctores.doctores_especialidad
WHERE
	idlicencia = 5


select * from config


update config set rutalogo = 'LogoCuerpoMedico.jpeg';


/* QUERY LISTADO CONSULTAS EMERGENCIAS */
SELECT 
	casomedico.idcasomedico, casomedico.cedula_paciente, 
	casomedico.problema_descripcion, casomedico.fecha, 
	paciente.nombre, paciente.apellido
FROM 
	casomedico
INNER JOIN paciente ON casomedico.cedula_paciente = paciente.cedula
WHERE
	1=1

/* QUERY REPORTE ESTADISTICAS CONSULTAS EMERGENCIAS */
SELECT
	upper(rangos.rango_descripcion) as rango, count(casomedico.rango) as cantidad
FROM
	casomedico
INNER JOIN rangos ON casomedico.rango = rangos.rango_id
GROUP by
	casomedico.rango

/* QUERY PARA CONSULTAR LOS CASOS MEDICOS CONSULTADOS EN EMERGENCIAS */
SELECT 
	casomedico.idcasomedico, casomedico.cedula_paciente, 
	casomedico.problema_descripcion, casomedico.fecha, paciente.nombre, 
	paciente.apellido, rangos.rango_descripcion           
FROM 
	casomedico
INNER JOIN paciente ON casomedico.cedula_paciente = paciente.cedula
INNER JOIN rangos ON casomedico.rango = rangos.rango_id


