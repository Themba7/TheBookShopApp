import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { BookShopAsset } from '../models/book-shop-asset';
import { ApiRequestService } from '../services/api/api-request.service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.scss']
})
export class CatalogComponent implements OnInit {

  constructor(private apiRequestService: ApiRequestService, private router: Router) { }
  
  assets: Array<BookShopAsset> = [];
  displayedColumns: string[] = ['id', 'imageUrl', 'title', 'cost'];
  dataSource = new MatTableDataSource<BookShopAsset>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnInit(): void {
    this.getCatalog();
  }

  async getCatalog(): Promise<void> {
    let result = await this.apiRequestService.getCatalog();

    if (result.IsSuccess) {
      this.assets = result.Data;
      this.dataSource = new MatTableDataSource(result.Data);
      this.dataSource.paginator = this.paginator;
    }
  }

  subscribe(rowData: BookShopAsset) {
    this.router.navigate(['/subscribe/book/', rowData.Id]);
  }

}
