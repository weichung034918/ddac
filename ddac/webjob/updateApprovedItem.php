<?php
	try
	{
		$connection = new PDO("sqlsrv:Server=tp034918.database.windows.net;Database=ddacassignment", "tp034918", "zaq1@WSX");
		$connection->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
		$connection->setAttribute(PDO::SQLSRV_ATTR_ENCODING, PDO::SQLSRV_ENCODING_SYSTEM);
	}catch (Exception $e)
	{
		echo $e->getMessage();
		die('Connection could not be established.<br />');
	}
	try
	{
		$sql = "UPDATE shipping SET status = 'PENDING ARRIVAL' WHERE status = 'APPROVED';";
		$query = $connection->prepare($sql);
		$query->execute();
		$result = $query->fetchAll(PDO::FETCH_ASSOC);
	}catch (Exception $e)
	{
		die('Cant fetch rows.');
	}
	foreach ($result as $r)
	{
	}
?>