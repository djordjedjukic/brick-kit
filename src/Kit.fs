module Kit

#r "nuget: FSharp.Data, 6.0.0"

open FSharp.Data
open Model

type ThemesTypeProvider = CsvProvider<Sample="../data/themes.csv">
type SetsTypeProvider = CsvProvider<Sample="../data/sets.csv">
type InventorySetsTypeProvider = CsvProvider<Sample="../data/inventory_sets.csv">
type InventoriesTypeProvider = CsvProvider<Sample="../data/inventories.csv">
type CategoriesTypeProvider = CsvProvider<Sample="../data/part_categories.csv">
type InventoryPartsTypeProvider = CsvProvider<Sample="../data/inventory_parts.csv">
type PartsTypeProvider = CsvProvider<Sample="../data/parts.csv">
type PartRelationshipsTypeProvider = CsvProvider<Sample="../data/part_relationships.csv">
type ElementsTypeProvider = CsvProvider<Sample="../data/elements.csv">
type MiniFigsTypeProvider = CsvProvider<Sample="../data/minifigs.csv">
type InventoryMiniFigsTypeProvider = CsvProvider<Sample="../data/inventory_minifigs.csv">
type ColorsTypeProvider = CsvProvider<Sample="../data/colors.csv">

let loadThemes =
    ThemesTypeProvider.GetSample().Rows
    |> Seq.map (fun t -> { Name = t.Name })

let loadSets =
    SetsTypeProvider.GetSample().Rows
    |> Seq.map (fun s -> { Number = s.Set_num
                           Name = s.Name
                           Year = s.Year
                           ThemeId = s.Theme_id
                           NumberOfParts = s.Num_parts })

