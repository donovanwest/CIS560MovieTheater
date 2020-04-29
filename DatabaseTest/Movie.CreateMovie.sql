CREATE OR ALTER PROCEDURE Movie.CreateMovie
   @Title NVARCHAR(75),
   @WorldwideGross BIGINT,
   @ReleaseDate DATE,   
   @MPAA_Rating NVARCHAR(10),
   @RottenTomatoesRating INT,
   @Director NVARCHAR(30),
   @MovieID INT OUTPUT
AS

INSERT MovieTheater.Movies(Title, Director, MPAA_Rating, RottenTomatoesRating, ReleaseDate, WorldwideGross)
VALUES(@Title, @Director, @MPAA_Rating, @RottenTomatoesRating, @ReleaseDate, @WorldwideGross);

SET @MovieID = SCOPE_IDENTITY();
GO
