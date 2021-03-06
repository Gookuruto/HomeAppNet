import { RecipesClient } from "../../webApi/api.generated.clients";
import { HttpClient } from "@angular/common/http";
import { Component, OnInit, ViewChild, AfterViewInit } from "@angular/core";
import { MatGridTileHeaderCssMatStyler } from "@angular/material/grid-list";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";
import { Sort } from "@angular/material/sort";

@Component({
  selector: "app-recipes-list",
  templateUrl: "./recipeList.component.html",
  styleUrls: ["./recipeList.component.css"],
})
export class RecipeListComponent implements OnInit, AfterViewInit {
  sortedData = [];
  dataSource = new MatTableDataSource();
  displayedColumns: string[] = ["position", "Url"];
  @ViewChild(MatSort, { static: false }) sort: MatSort;
  constructor(private http: HttpClient, private recipesClient: RecipesClient) {}

  async ngOnInit(): Promise<void> {
    const data = await this.recipesClient
      .get(1, 100, null, false, "")
      .toPromise();
    this.dataSource = new MatTableDataSource(data);
  }
  ngAfterViewInit(): void {}

  // sortData(sort: Sort): void {
  //   const data = this.books.slice();
  //   if (!sort.active || sort.direction === "") {
  //     this.sortedData = data;
  //     return;
  //   }

  //   this.sortedData = data.sort((a, b) => {
  //     const isAsc = sort.direction === "asc";
  //     switch (sort.active) {
  //       case "position":
  //         return this.compare(a.id, b.id, isAsc);
  //       case "title":
  //         return this.compare(a.title, b.title, isAsc);
  //       case "author":
  //         return this.compare(a.author, b.author, isAsc);
  //       default:
  //         return 0;
  //     }
  //   });
  // }
  // private compare(a, b, isAsc): number {
  //   if (isAsc) {
  //     return a < b ? -1 : 1;
  //   } else {
  //     return a < b ? 1 : -1;
  //   }
  // }
}
