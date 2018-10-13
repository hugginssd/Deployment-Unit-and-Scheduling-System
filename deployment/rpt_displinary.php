<table width="100%">

	<tr>
		<td><img src="romicon.jpg" width="200px"/></td>
		<td>
			<h1>ZRP Services</h1>
			<h3>Displinary Report</h3>
		</td>
	</tr>
</table>
<table width="100%" cellpadding="1" cellspacing="1" bgcolor="#666666">

	<tr>
		<th>Force NO</th>
		<th>ID Number</th>
		<th>First names</th>
		<th>Last name</th>
		<th>Date</th>
		<th>Section</th>
		<th>Action</th>
		<th>Notes</th>
	</tr>
	<?php 
		include("config.php");
		$rs = $mysqli->query("select tbl_employee.*, tbl_displinary.*
						from tbl_employee, tbl_displinary
						where tbl_employee.id = tbl_displinary.employee_id");
		while ($row = $rs->fetch_assoc()){
	?>
	
	<tr>
	
		<td bgcolor="#FFFFFF"><?php echo $row['employee_number']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['id_number']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['firstnames']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['lastname']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['date']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['section']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['action']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['notes']; ?></td>
		
	</tr>
	
	<?php } ?>
</table>