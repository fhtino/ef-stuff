# ef-stuff
Miscellaneous Entity Framework examples

## EF class-name collision

Environment: C#, .NET Framework, Entity Framework 6.5.2

If two `DbContext` types contain classes with the same name and properties, the project compiles successfully but throws an exception at runtime, even when the classes are in different .NET namespaces. EF cannot determine which class to use because it ignores namespaces.

The example project contains two EDMX files in separate folders and namespaces: `FolderX` and `FolderY`. The generated classes are valid from .NET's point of view. For example, `EFClassCollision.FolderX.Product` and `EFClassCollision.FolderY.Product` are distinct classes. However, EF cannot distinguish between them and throws an exception.

```
var db = new ContosoEntitiesX();
var p = db.Products.First();
```

Exception:

```
Unhandled Exception: System.Data.Entity.Core.MetadataException: Schema specified is not valid. Errors:

The mapping of CLR type to EDM type is ambiguous because multiple CLR types match the EDM type 'Customer'. Previously found CLR type 'EFClassCollision.FolderY.Customer', newly found CLR type 'EFClassCollision.FolderX.Customer'.

The mapping of CLR type to EDM type is ambiguous because multiple CLR types match the EDM type 'Product'. Previously found CLR type 'EFClassCollision.FolderY.Product', newly found CLR type 'EFClassCollision.FolderX.Product'.

   at System.Data.Entity.Core.Metadata.Edm.ObjectItemCollection.LoadAssemblyFromCache
   (Assembly assembly, Boolean loadReferencedAssemblies, EdmItemCollection edmItemCollection, Action`1 logLoadMessage)
```

<br/>

**HOW TO SOLVE**

Place the two `DbContext` in separated assemblies. The solution `EFClassCollisionTwoAssemblies` shows this approach: a console app using two assemblies: LibA and LibB, each hosting a `DbContext` on the same database and same tables. In console app we can use both models without issues.

Console app output:

```
Reading from LibA.ContosoEntitiesA:  --> Contoso 512MB MP3 Player E51 Silver [1]
Reading from LibB.ContosoEntitiesB:  --> Contoso 512MB MP3 Player E51 Silver [1]
```