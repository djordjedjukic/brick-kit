module BrickData

open System.IO
open FSharp.Data

type Color = {
    Id: int
    Name: string
    RGB: string
    IsTransparent: bool
}

type Category = { Id: int; Name: string }

type Part = {    
    Number: string
    Name: string
    Material: string
    Category: Category
}

type InventoryPart = {
    InventoryId: int
    PartNumber: string
    Color: Color
    Quantity: int
    IsSpare: bool
}

type Inventory = {
    Id: int
    Version: int
    SetNumber: string
}

type Theme = { Id: int; Name: string }

type Set = {
    Number: string
    Name: string
    Year: int
    ThemeId: int
    NumberOfParts: int
    Inventories: Inventory list
}

type MiniFig = {
    Number: string
    Name: string
    NumberOfParts: int
}

let basePath =
    System.AppDomain.CurrentDomain.BaseDirectory
    |> DirectoryInfo
    |> (fun dir -> dir.Parent.Parent.Parent.Parent.FullName)

let filePath = Path.Combine(basePath, "data")

type ThemesTypeProvider = CsvProvider<"../data/themes.csv">
let themesData = ThemesTypeProvider.Load(Path.Combine(filePath, "themes.csv"))
type SetsTypeProvider = CsvProvider<"../data/sets.csv">
let setsData = SetsTypeProvider.Load(Path.Combine(filePath, "sets.csv"))
type InventorySetsTypeProvider = CsvProvider<"../data/inventory_sets.csv">
type InventoriesTypeProvider = CsvProvider<"../data/inventories.csv">

let inventoriesData =
    InventoriesTypeProvider.Load(Path.Combine(filePath, "inventories.csv"))

type CategoriesTypeProvider = CsvProvider<"../data/part_categories.csv">
let categoriesData = CategoriesTypeProvider.Load(Path.Combine(filePath, "part_categories.csv"))
type InventoryPartsTypeProvider = CsvProvider<"../data/inventory_parts.csv">

let inventoryPartsData =
    InventoryPartsTypeProvider.Load(Path.Combine(filePath, "inventory_parts.csv"))

type PartsTypeProvider = CsvProvider<"../data/parts.csv">
let partsData = PartsTypeProvider.Load(Path.Combine(filePath, "parts.csv"))
type PartRelationshipsTypeProvider = CsvProvider<"../data/part_relationships.csv">
type ElementsTypeProvider = CsvProvider<"../data/elements.csv">
type MiniFigsTypeProvider = CsvProvider<"../data/minifigs.csv">
type InventoryMiniFigsTypeProvider = CsvProvider<"../data/inventory_minifigs.csv">
type ColorsTypeProvider = CsvProvider<"../data/colors.csv">
let colorsData = ColorsTypeProvider.Load(Path.Combine(filePath, "colors.csv"))


let themes = themesData.Rows |> Seq.map (fun t -> { Id = t.Id; Name = t.Name })

let sets =
    setsData.Rows
    |> Seq.map (fun s -> {
        Number = s.Set_num
        Name = s.Name
        Year = s.Year
        ThemeId = s.Theme_id
        NumberOfParts = s.Num_parts
        Inventories = []
    })

let inventories =
    inventoriesData.Rows
    |> Seq.map (fun i -> {
        Id = i.Id
        Version = i.Version
        SetNumber = i.Set_num
    })

let colors =
    colorsData.Rows
    |> Seq.map (fun c -> {
        Id = c.Id
        Name = c.Name
        RGB = c.Rgb
        IsTransparent = match c.Is_trans with | "t" -> true | "f" -> false
    })

let categories : (Category seq) =
    categoriesData.Rows
    |> Seq.map (fun c -> { Id = c.Id; Name = c.Name })
    
let parts =
    partsData.Rows
    |> Seq.map (fun p -> {
        Number = p.Part_num
        Name = p.Name
        Material = p.Part_material 
        Category = categories |> Seq.find (fun c -> c.Id = p.Part_cat_id)        
    })    

let inventoryParts =
    inventoryPartsData.Rows
    |> Seq.map (fun i -> {
        InventoryId = i.Inventory_id
        PartNumber = i.Part_num
        Color = colors |> Seq.find (fun c -> c.Id = i.Color_id)
        Quantity = i.Quantity
        IsSpare = match i.Is_spare with | "t" -> true | "f" -> false
    })
