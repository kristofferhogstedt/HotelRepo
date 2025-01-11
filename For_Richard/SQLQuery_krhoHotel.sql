SELECT 
	RoomTypeAndDetails.RoomType
	, RoomTypeAndDetails.Size
	, RoomTypeAndDetails.NumberOfBeds
	, RoomTypeAndDetails.Price
	, Count(ROOM.ID) AS NumberOfRooms
FROM Rooms AS ROOM
INNER JOIN
(
	SELECT ROOMD.RoomID, ROOMT.ID AS RoomTypeID, ROOMT.Name AS RoomType, ROOMD.Size, ROOMD.NumberOfBeds, ROOMD.Price
	FROM RoomDetails AS ROOMD
	INNER JOIN RoomTypes AS ROOMT
	ON ROOMD.RoomTypeID=ROOMT.ID 
	WHERE ROOMT.Name<>'Suite'
) AS RoomTypeAndDetails
ON ROOM.ID=RoomTypeAndDetails.RoomID
GROUP BY RoomTypeAndDetails.RoomTypeID, RoomTypeAndDetails.RoomType, RoomTypeAndDetails.Size, RoomTypeAndDetails.NumberOfBeds, RoomTypeAndDetails.Price
ORDER BY RoomTypeAndDetails.RoomTypeID

