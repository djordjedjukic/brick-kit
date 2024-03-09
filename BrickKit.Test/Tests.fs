module Tests

open Xunit
open Kit

    module Themes = 
        [<Fact>]
        let ``Find theme by name`` () =
            let theme = Themes.findByName "Speed Champions"
            Assert.True(theme.IsSome)
            Assert.Equal("Speed Champions", theme.Value.Name)
            Assert.Equal(601, theme.Value.Id)
    module Sets = 
        [<Fact>]
        let ``Find sets by theme id`` () =
            let sets = Sets.findByThemeId 601
            Assert.Equal(65, sets |> Seq.length)
            
        [<Fact>]    
        let ``Find sets by theme name`` () =
            let sets = Sets.findByThemeName "Speed Champions"    
            Assert.Equal(65, sets |> Seq.length)

        [<Fact>]
        let ``Find sets by year`` () =
            let sets = Sets.findByYear 2010    
            Assert.Equal(527, sets |> Seq.length)
            
        [<Fact>]
        let ``Find sets by years`` () =
            let sets = Sets.findByYears [2010; 2011]    
            Assert.Equal(1146, sets |> Seq.length)
            
        [<Fact>]
        let ``Find sets by set number`` () =
            let set = Sets.findByNumber "75995-1"    
            Assert.True(set.IsSome)
            Assert.Equal("75995-1", set.Value.Number)
            Assert.Equal(2017, set.Value.Year)
            Assert.Equal(601, set.Value.ThemeId)
            Assert.Equal("MERCEDES-AMG PETRONAS Team Gift 2017", set.Value.Name)
            
        [<Fact>]
        let ``Find sets by set name`` () =
            let set = Sets.findByName "MERCEDES-AMG PETRONAS Team Gift 2017"    
            Assert.True(set.IsSome)
            Assert.Equal("75995-1", set.Value.Number)
            Assert.Equal(2017, set.Value.Year)
            Assert.Equal(601, set.Value.ThemeId)
            Assert.Equal("MERCEDES-AMG PETRONAS Team Gift 2017", set.Value.Name)