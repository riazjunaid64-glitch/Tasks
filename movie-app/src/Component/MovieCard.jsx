
const styles = {
  card:     "flex flex-col w-full rounded-xl overflow-hidden shadow-lg bg-gray-900 hover:scale-105 transition-transform duration-200 cursor-pointer",
  image:    "w-full h-[270px] object-cover",
  body:     "flex flex-col gap-1 p-3",
  title:    "text-white font-semibold text-sm leading-tight line-clamp-2",
  subtitle: "text-gray-400 text-xs",
  badge:    "text-orange-400 text-xs font-medium",
};

const FALLBACK_POSTER =
  "data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='200' height='270'><rect width='100%25' height='100%25' fill='%23111827'/><text x='50%25' y='50%25' fill='%239ca3af' font-family='Arial' font-size='16' text-anchor='middle' dominant-baseline='middle'>No Poster</text></svg>";

function MovieCard({ movie }) {
  const posterSrc =
    movie?.Poster && movie.Poster !== "N/A" ? movie.Poster : FALLBACK_POSTER;

return (
  <a
    href={`https://www.imdb.com/title/${movie?.imdbID}`}
    target="_blank"
    rel="noopener noreferrer"
    className={styles.card}
  >
    <img
      src={posterSrc}
      alt={movie?.Title || "Movie poster"}
      className={styles.image}
      onError={(e) => {
        e.currentTarget.src = FALLBACK_POSTER;
      }}
    />
    <div className={styles.body}>
      <h2 className={styles.title}>{movie?.Title}</h2>
    </div>
  </a>
);
}

export default MovieCard;
