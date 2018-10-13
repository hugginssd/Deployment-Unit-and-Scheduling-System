<table width="100%">

	<tr>
		<td><img src="romicon.jpg" width="200px"/></td>
		<td>
			<h1>Romicon Security</h1>
			<h3>Payments Report</h3>
		</td>
	</tr>
</table>
<table width="100%" cellpadding="1" cellspacing="1" bgcolor="#666666">

	<tr>
		<th>Force NO</th>
		<th>ID Number</th>
		<th>First names</th>
		<th>Last name</th>
		<th>Pay date</th>
		<th>Basic Salary</th>
		<th>Deductions</th>
		<th>Net pay</th>
	</tr>
	<?php 
		include("config.php");
		$rs = $mysqli->query("select * from tbl_payroll where month(Date_payed) = $_GET[month]");
		while ($row =$rs->fetch_assoc()){
	?>
	
	<tr>
	
		<td bgcolor="#FFFFFF"><?php echo $row['Employ_id']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['ID_No']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['Emp_fname']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['Surname']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['Date_payed']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['Basic_salary']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['Deductions']; ?></td>
		<td bgcolor="#FFFFFF"><?php echo $row['Payment']; ?></td>
		
	</tr>
	
	<?php } ?>
</table>