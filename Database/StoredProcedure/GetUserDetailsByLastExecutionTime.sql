
CREATE PROCEDURE GetUserDetailsByLastExecutionTime
    @LastExecutionTime DATETIME
AS
BEGIN
    SELECT
        RecordId,
        UserId,
        UserName,
        UserEmail,
        DataValue,
        NotificationFlag
    FROM
        UserData
    WHERE
        CreatedDate > @LastExecutionTime OR UpdatedDate > @LastExecutionTime
END;