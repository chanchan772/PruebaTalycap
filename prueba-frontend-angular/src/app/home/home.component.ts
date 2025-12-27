import { Component, OnInit, ViewChild } from '@angular/core';
import { MovieService } from '../services/movie.service';
import { Movie } from '../core/models/movie';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
  ],
})
export class HomeComponent implements OnInit {
  dataSource = new MatTableDataSource<Movie>();
  displayedColumns: string[] = ['poster', 'title', 'release_date', 'vote_average'];
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  
  private searchSubject = new Subject<string>();

  constructor(private movieService: MovieService) {
    this.searchSubject.pipe(
      debounceTime(300),
      distinctUntilChanged()
    ).subscribe(query => {
      this.dataSource.filter = query.trim().toLowerCase();
    });
  }

  ngOnInit(): void {
    this.loadMovies();
  }

  loadMovies(page: number = 1): void {
    this.movieService.getPopularMovies(page).subscribe(response => {
      this.dataSource.data = response.results;
      this.paginator.length = response.total_results;
      this.paginator.pageIndex = response.page - 1;
    });
  }

  onPageChange(event: any): void {
    this.loadMovies(event.pageIndex + 1);
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.searchSubject.next(filterValue);
  }
}
