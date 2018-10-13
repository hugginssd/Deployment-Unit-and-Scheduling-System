<?php 

	include("config.php");
	
	$rs = mysql_query("select * from edms.empl_reg");
	while($row = mysql_fetch_array($rs)){
	
		//mysql_query("insert into guard.tbl_employee(employee_number,firstnames,lastname,id_number,job_title,address,picture) values('$row[Employee_id]','$row[First_name]','$row[Surname]','$row[Id_no]','$row[Job_title]','$row[Residential_address]','$row[Employee_pic]')") or die(mysql_query());
	}
?>