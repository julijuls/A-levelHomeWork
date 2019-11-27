USE [HumanResources]
GO

SELECT [OrderProductRelation].[id]
      ,[Orders].[Order ID],[Orders].[Order Date],[Orders].[Ship Date],[ShipModes].[ShipMode]
	  ,[Customers].[Customer ID],[Customers].[Customer Name],[Segments].Segment,
	  [Counties].[Country],[Cities].[City],[States].[state],[PostData].[Postal_Code],Regions.Region,
	  [Categories].Category,  [SubCategories].[Sub-Category],
	  [Products].[Product Name]
      ,[Products].[Product ID],
     [Products].[Cost]*[Quantity]*(1-[Discount]) as Sales
      ,[Quantity]
      ,[Discount]
      ,[Profit]
  FROM [dbo].[OrderProductRelation]
  inner join [Orders]    on [Orders].[id_Order]=[OrderProductRelation].[Order ID] 
  inner join [Products]  on [Products].[id_product]=[OrderProductRelation].[Product ID]
  inner join [Customers] on [Orders].[Customer ID]=[Customers].id_custumer
  inner join [PostData]  on [PostData].[id_post]=Orders.[Post_ID]
  inner join [Counties]  on [PostData].[Country_id]=[Counties].[id_Country]
  inner join [Cities]    on [PostData].[City_id]=[Cities].[id_City]
  inner join [States]      on [PostData].[State_id]=[States].[id_state]
  inner join [Regions]     on [PostData].[Region]=[Regions].[id_Region]
  inner join  [ShipModes]  on [Orders].[Ship Mode]=[ShipModes].[id_shipmode]
  inner join [Segments]  on [Segments].[id_Segment]=[Customers].[Segment_id]
  inner join [SubCategories] on [SubCategories].[id_Sub-Category]=[Products].[Sub-Category_id]
  inner join [Categories] on [Categories].[id_Category]=[SubCategories].[Category_id]

GO


 CREATE  FUNCTION ProductCost(@Sales money ,@Quantity money,@Discount money) Returns money
 as
 begin
 declare @Cost Money
 SET @Cost=(@Sales/@Quantity/(1-@Discount));
 return @Cost;
 end;
