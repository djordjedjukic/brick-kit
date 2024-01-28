module Data

open FSharp.Data

type Theme = {
    Id: int
    Name: string
}

type Set = {
    Number: string
    Name: string
    Year: int
    ThemeId: int
    NumberOfParts: int
}

type MiniFig = {
    Number: string
    Name: string
    NumberOfParts: int
}

type Color = {
    Name: string
    RGB: string
}

type Part = {
    Category: string
    Number: string
    Name: string
    Color: Color
}

type Inventory = {    
    Parts: Part list
    Quantity: int
    IsSpare: bool   
}

type ThemesTypeProvider = CsvProvider<"../data/themes.csv">
type SetsTypeProvider = CsvProvider<"../data/sets.csv">
type InventorySetsTypeProvider = CsvProvider<"../data/inventory_sets.csv">
type InventoriesTypeProvider = CsvProvider<"../data/inventories.csv">
type CategoriesTypeProvider = CsvProvider<"../data/part_categories.csv">
type InventoryPartsTypeProvider = CsvProvider<"../data/inventory_parts.csv">
type PartsTypeProvider = CsvProvider<"../data/parts.csv">
type PartRelationshipsTypeProvider = CsvProvider<"../data/part_relationships.csv">
type ElementsTypeProvider = CsvProvider<"../data/elements.csv">
type MiniFigsTypeProvider = CsvProvider<"../data/minifigs.csv">
type InventoryMiniFigsTypeProvider = CsvProvider<"../data/inventory_minifigs.csv">
type ColorsTypeProvider = CsvProvider<"../data/colors.csv">

let themes =
    ThemesTypeProvider.GetSample().Rows
    |> Seq.map (fun t -> { Id = t.Id; Name = t.Name })

let sets =
    SetsTypeProvider.GetSample().Rows
    |> Seq.map (fun s -> { Number = s.Set_num
                           Name = s.Name
                           Year = s.Year
                           ThemeId = s.Theme_id
                           NumberOfParts = s.Num_parts })