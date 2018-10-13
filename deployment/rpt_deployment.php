<table width="100%">

	<tr>
		<td><img src="romicon.jpg" width="200px"/></td>
		<td>
			<h1>ZRP Services</h1>
			<h3>Deployments Report</h3>
		</td>
	</tr>
</table>
<table width="100%" cellpadding="1" cellspacing="1" bgcolor="#666666">

	<tr>
		<th>Force NO</th>
		<th>ID Number</th>
		<th>First names</th>
		<th>Last name</th>
		<th>Station Name</th>
		<th>Deployment Date</th>
		<th>Number of days</th>
	</tr>
	<?php 
		include("config.php");
		
		
		$rs = $mysqli->query("select tbl_employee.*, tbl_deployment.date_deployed, tbl_deployment.days, tbl_contract.contract_name 
						from tbl_employee, tbl_contract, tbl_deployment, tbl_site
						where tbl_contract.id =  $_GET[contract]
						and tbl_contract.id = tbl_site.contract_id
						and tbl_site.id = tbl_deployment.site_id
						and tbl_deployment.date_deployed between '$_GET[start]' and '$_GET[end]'");
		while ($row = $rs->fetch_assoc()){
	?>
	
	<tr>
	
		<td bgcolor="#FFFFFF"><?php echo $row['employee_number']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['id_number']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['firstnames']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['lastname']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['contract_name']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['date_deployed']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['days']; ?></td>
		
	</tr>
	
	<?php } ?>
</table>