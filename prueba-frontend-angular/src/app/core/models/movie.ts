export interface Movie {
    id: number;
    title: string;
    release_date: string;
    vote_average: number;
    poster_path: string;
}

export interface MovieResponse {
    results: Movie[];
    page: number;
    total_pages: number;
    total_results: number;
}
