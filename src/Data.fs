module Data

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

type Theme = {
    Id: int
    Name: string
    Sets: Set list
}

and Set = {
    Number: string
    Name: string
    Year: int
    Theme: Theme
    NumberOfParts: int
    Inventories: Inventory list
}

type MiniFig = {
    Number: string
    Name: string
    NumberOfParts: int
}

type ThemesTypeProvider = CsvProvider<"../data/themes.csv">
let themesData = ThemesTypeProvider.Load("../data/themes.csv")
type SetsTypeProvider = CsvProvider<"../data/sets.csv">
let setsData = SetsTypeProvider.Load("../data/sets.csv")
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
    themesData.Rows
    |> Seq.map (fun t -> {
        Id = t.Id
        Name = t.Name
        Sets =
            setsData.Rows
             |> Seq.filter (fun s -> s.Theme_id = t.Id)
             |> Seq.map (fun s -> {
                 Number = s.Set_num
                 Name = s.Name
                 Year = s.Year
                 Theme = { Id = t.Id; Name = t.Name; Sets = [] }
                 NumberOfParts = s.Num_parts
                 Inventories = []
             })
             |> Seq.toList
             
    })
    
let sets =
    SetsTypeProvider.GetSample().Rows
    |> Seq.map (fun s -> {
        Number = s.Set_num
        Name = s.Name
        Year = s.Year
        Theme = themes |> Seq.find (fun t -> t.Id = s.Theme_id)
        NumberOfParts = s.Num_parts
        Inventories = []
    })