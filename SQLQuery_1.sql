USE Library
CREATE FUNCTION ChooseCategory(@CategoryId int)
RETURNS TABLE
AS
RETURN
(
   SELECT DISTINCT A.FirstName +' '+ A.LastName AS 'Fullname'
   FROM Authors AS A
   JOIN Books AS B ON B.Id_Author = A.Id
   WHERE B.Id_Category=@CategoryId
)

CREATE FUNCTION ChooseAuthors(@author NVARCHAR(MAX),@CategoryId int)
RETURNS TABLE
AS
RETURN
(
    SELECT DISTINCT B.Name
    FROM Books AS B
    JOIN Authors AS A ON B.Id_Author = A.Id
    JOIN Categories AS C ON B.Id_Category = C.Id
    WHERE A.FirstName+' '+A.LastName = @author
      AND C.Id = @CategoryId
)


CREATE PROCEDURE UpdateBookPage
    @BookName NVARCHAR(MAX),
    @NewPage int 
AS
BEGIN
    UPDATE Books
    SET Pages= @NewPage
    WHERE [Name] = @BookName;
END;
GO

CREATE PROCEDURE UpdateBookQuantity
    @BookName NVARCHAR(MAX),
    @NewQuantity int 
AS
BEGIN
    UPDATE Books
    SET Quantity= @NewQuantity
    WHERE [Name] = @BookName;
END;
GO






