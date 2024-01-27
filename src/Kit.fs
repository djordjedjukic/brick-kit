module Kit

open FSharp.Data

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
let parts = PartsTypeProvider.GetSample().Rows

let printFirst10Parts () =
    parts
    |> Seq.take 10
    |> Seq.map (fun p -> p.Part_num, p.Name) 
    |> Map.ofSeq
    |> Map.iter (fun key value -> printfn "%A: %A" key value)

printFirst10Parts ()

