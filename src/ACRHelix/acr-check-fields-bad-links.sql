update [dbo].[VersionedFields]
set Value = REPLACE(value,'/login.acr.org','/login75.acr.org')
where Value like '%/login.acr.org%'

update [dbo].[VersionedFields]
set Value = REPLACE(value,'//shop75.acr.org','//stgshop75.acr.org')
where Value like '%//shop75.acr.org%'

update [dbo].[VersionedFields]
set Value = REPLACE(value,'//shop.acr.org','//stgshop75.acr.org')
where Value like '%//shop.acr.org%'

update [dbo].[VersionedFields]
set Value = REPLACE(value,'//qa.acr.org','//staging.acr.org')
where Value like '%//qa.acr.org%'

update [dbo].[VersionedFields]
set Value = REPLACE(value,'//acr.org','//staging.acr.org')
where Value like '%//acr.org%'


update [dbo].[VersionedFields]
set Value = REPLACE(value,'//www.acr.org','//staging.acr.org')
where Value like '%//www.acr.org%'


SELECT 
l.ItemId,
l.FieldId,
l.Value
FROM [ACRHelix_master].[dbo].[VersionedFields] l
where Value like 
'%/shop.acr.org%'
order by FieldId

SELECT 
l.ItemId,
l.FieldId,
l.Value
FROM [ACRHelix_master].[dbo].[VersionedFields] l
where Value like 
'%/shop75.acr.org%'
order by FieldId


SELECT 
l.ItemId,
l.FieldId,
l.Value
FROM [ACRHelix_master].[dbo].[VersionedFields] l
where Value like 
'%/acr.org%'
order by FieldId

SELECT 
l.ItemId,
l.FieldId,
l.Value
FROM [ACRHelix_master].[dbo].[VersionedFields] l
where Value like 
'%/qa.acr.org%'
order by FieldId

SELECT 
l.ItemId,
l.FieldId,
l.Value
FROM [ACRHelix_master].[dbo].[VersionedFields] l
where Value like 
'%/www.acr.org%'
order by FieldId

SELECT 
l.ItemId,
l.FieldId,
l.Value
FROM [ACRHelix_master].[dbo].[VersionedFields] l
where Value like 
'%/login.acr.org%'
order by FieldId