use mdeg_dispensariomedico;

select * from departamentos;
select * from doctores;
select * from especialidades;
select * from departamentos;
select * from especialidades_tipo;
select * from especialidades;
select * from paciente;
select * from rangos;
select * from seccionaval;
select * from invent order by secuencia desc;
select * from t_mov;
select * from mproduct order by des_pro;
select * from catego;
select * from subcatego ;
select * from usuario ;
select * from errors order by secuencia desc;
select * from backup;
select * from config;
select * from mproduct;
select * from mitbis;
select * from mpresen;


-- INSERT INTO mdeg_dispensariomedico.invent (SELECT * FROM telemar.invent)
-- select * from vpaciente where cedula = "018-0045642-6";
-- update invent set cedula = "999-9999999-9" where secuencia != 0;
-- update doctores set fechanac = date_add(now(), interval -20 year)


/*
UPDATE MPRODUCT SET cod_cat = "001";
UPDATE MPRODUCT SET TIPO_PRO = "0001";
UPDATE MPRODUCT SET codIGO = 1;
UPDATE MPRODUCT SET CODIGO2 = 1;
UPDATE MPRODUCT SET codIGO3 = 1;
UPDATE MPRODUCT SET INVENTARIO = 1;
UPDATE MPRODUCT SET STATUS ="S";
UPDATE MPRODUCT SET STATUS2 = "A";
UPDATE MPRODUCT SET ALMACEN1 = CANT_EXIST;
UPDATE MPRODUCT SET COD_PRO2 = cod_pro;
SELECT * FROM MPRODUCT;  */
