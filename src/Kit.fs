module Kit

open FSharp.Data

type PartsTypeProvider = CsvProvider<Sample="../data/parts.csv">
let parts = PartsTypeProvider.GetSample().Rows

let printFirst10Parts () =
    parts
    |> Seq.take 10
    |> Seq.map (fun p -> p.Part_num, p.Name) 
    |> Map.ofSeq
    |> Map.iter (fun key value -> printfn "%A: %A" key value)

printFirst10Parts ()

