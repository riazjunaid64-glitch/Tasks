import { useState } from "react";
import MovieCard from "./Component/MovieCard";
import { fetchMovies } from "./Services/omdbApi";


const styles = {
  page:        "min-h-screen bg-gray-950 text-white px-6 py-10",
  heading:     "text-4xl font-bold text-center mb-8 tracking-tight",
  searchWrap:  "flex items-center gap-2 max-w-xl mx-auto mb-10",
  input:       "flex-1 px-4 py-2 rounded-lg bg-gray-800 text-white placeholder-gray-500 outline-none focus:ring-2 focus:ring-orange-500",
  button:      "px-5 py-2 rounded-lg bg-orange-500 hover:bg-orange-600 font-semibold transition-colors",
  grid:        "grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-6",
  empty:       "text-center text-gray-500 mt-20 text-lg",
};


function App() {
  const [search, setSearch] = useState("");
  const [movies, setMovies] = useState([]);

  const handleSearch = async () => {
     if (search.length < 3) {
  alert("Please enter more specific search (at least 3 characters)");
  return;
}
    if (!search.trim()) return;
    const results = await fetchMovies(search);
    setMovies(results);
    
  };
 

  return (
    <div className={styles.page}>
      <h1 className={styles.heading}>🎬 Movie Search</h1>

      <div className={styles.searchWrap}>
        <input
          className={styles.input}
          type="text"
          value={search}
          placeholder="Search for a movie..."
          onChange={(e) => setSearch(e.target.value)}
          onKeyDown={(e) => e.key === "Enter" && handleSearch()}
        />
        <button className={styles.button} onClick={handleSearch}>Search</button>
      </div>

      {movies.length === 0 ? (
        <p className={styles.empty}>Search for a title to get started.</p>
      ) : (
        <div className={styles.grid}>
          {movies.map((movie) => (
            <MovieCard key={movie.imdbID} movie={movie} />
          ))}
        </div>
      )}
    </div>
  );
}

export default App;