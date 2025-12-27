import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { MovieResponse } from '../core/models/movie'; // Adjusted import path

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  private movieDataUrl = 'assets/data/movies.json';
  private allMovies: MovieResponse | undefined;

  constructor(private http: HttpClient) { }

  private getMovieData(): Observable<MovieResponse> {
    if (this.allMovies) {
      return of(this.allMovies);
    }
    return this.http.get<MovieResponse>(this.movieDataUrl).pipe(
      map(data => {
        this.allMovies = data;
        return data;
      })
    );
  }

  getPopularMovies(page: number = 1, pageSize: number = 20): Observable<MovieResponse> {
    return this.getMovieData().pipe(
      map(response => {
        const startIndex = (page - 1) * pageSize;
        const endIndex = startIndex + pageSize;
        const pagedResults = response.results.slice(startIndex, endIndex);

        return {
          results: pagedResults,
          page: page,
          total_pages: Math.ceil(response.results.length / pageSize),
          total_results: response.results.length
        };
      })
    );
  }

  searchMovies(query: string, page: number = 1, pageSize: number = 20): Observable<MovieResponse> {
    return this.getMovieData().pipe(
      map(response => {
        const filteredResults = response.results.filter(movie =>
          movie.title.toLowerCase().includes(query.toLowerCase())
        );

        const startIndex = (page - 1) * pageSize;
        const endIndex = startIndex + pageSize;
        const pagedResults = filteredResults.slice(startIndex, endIndex);

        return {
          results: pagedResults,
          page: page,
          total_pages: Math.ceil(filteredResults.length / pageSize),
          total_results: filteredResults.length
        };
      })
    );
  }
}
