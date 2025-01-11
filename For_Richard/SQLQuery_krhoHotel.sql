-- Query displays number of rooms per RoomTypes/Size/Number of beds
-- SELECT, WHERE, ORDER BY, GROUP BY and a subquery

SELECT 
	RoomTypeAndDetails.RoomType
	, RoomTypeAndDetails.Size
	, RoomTypeAndDetails.NumberOfBeds
	, Count(ROOM.ID) AS NumberOfRooms
FROM Rooms AS ROOM
INNER JOIN
(
	SELECT ROOMD.RoomID, ROOMT.ID AS RoomTypeID, ROOMT.Name AS RoomType, ROOMD.Size, ROOMD.NumberOfBeds
	FROM RoomDetails AS ROOMD
	INNER JOIN RoomTypes AS ROOMT
	ON ROOMD.RoomTypeID=ROOMT.ID 
	WHERE ROOMT.Name<>'Suite'
) AS RoomTypeAndDetails
ON ROOM.ID=RoomTypeAndDetails.RoomID
GROUP BY RoomTypeAndDetails.RoomTypeID, RoomTypeAndDetails.RoomType, RoomTypeAndDetails.Size, RoomTypeAndDetails.NumberOfBeds
ORDER BY RoomTypeAndDetails.RoomTypeID

