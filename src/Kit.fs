module Kit

open Data

    [<RequireQualifiedAccess>]    
    module Themes =
        let   (name: string) =
            themes
            |> Seq.filter (fun part -> part.Name.Contains name)
            
        let sets = 
            sets
            |> Seq.map (fun part -> part.Theme)
            
    [<RequireQualifiedAccess>]    
    module Sets =
        let byName (name: string) =
            sets
            |> Seq.filter (fun part -> part.Name.Contains name)
            
        let byTheme (themeName: string) =
            sets
            |> Seq.filter (fun part -> part.Theme.Name = Themes.byName themeName |> Seq.head.Id)
            
            
            
            