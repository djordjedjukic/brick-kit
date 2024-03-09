module BrickData

open System.IO
open FSharp.Data

type Color = { Name: string; RGB: string }

type Category = {
    Id: int
    Name: string
    Parts: Part list
}

and Part = {
    Category: Category
    Number: string
    Name: string
}

type InventoryPart = {
    Number: string
    Color: Color
    IsSpare: bool
}

type Inventory = {
    Id: int
    Version: int
    Parts: InventoryPart list
}

type Theme = { Id: int; Name: string }

and Set = {
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
type CategoriesTypeProvider = CsvProvider<"../data/part_categories.csv">
//let categoriesData = CategoriesTypeProvider.Load(Path.Combine(filePath, "categories.csv"))
type InventoryPartsTypeProvider = CsvProvider<"../data/inventory_parts.csv">
type PartsTypeProvider = CsvProvider<"../data/parts.csv">
//let partsData = PartsTypeProvider.Load(Path.Combine(filePath, "parts.csv"))
type PartRelationshipsTypeProvider = CsvProvider<"../data/part_relationships.csv">
type ElementsTypeProvider = CsvProvider<"../data/elements.csv">
type MiniFigsTypeProvider = CsvProvider<"../data/minifigs.csv">
type InventoryMiniFigsTypeProvider = CsvProvider<"../data/inventory_minifigs.csv">
type ColorsTypeProvider = CsvProvider<"../data/colors.csv">
//let colorsData = ColorsTypeProvider.Load(Path.Combine(filePath, "colors.csv"))


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

(*let colors =
    colorsData.Rows
    |> Seq.map (fun c -> {
        Name = c.Name
        RGB = c.Rgb
    })*)
