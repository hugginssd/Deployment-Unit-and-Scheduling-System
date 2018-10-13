<table width="100%">

	<tr>
		<td><img src="romicon.jpg" width="200px"/></td>
		<td>
			<h1>ZRP Services</h1>
			<h3>Stations Report</h3>
		</td>
	</tr>
</table>

<table width="100%" cellpadding="1" cellspacing="1" bgcolor="#666666">
	<tr>
		<th>Station NO</th>
		<th>Station Name</th>
		<th>Start date</th>
		<th>End date</th>
		<th>Number of officers</th>
	</tr>
	<?php 
		include("config.php");
		$rs = $mysqli->query("select * from tbl_contract");
		while ($row = $rs->fetch_assoc()){
	?>
	
	<tr>
	
		<td bgcolor="#FFFFFF"><?php echo $row['contract_number']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['contract_name']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['start_date']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['end_date']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['number_of_guards']; ?></td>
		
	</tr>
	
	<?php } ?>
</table>