const API_KEY = "4a1fe303";

export const fetchMovies = async (searchTerm) => {
  const query = encodeURIComponent(searchTerm.trim());
  const response = await fetch(
    `https://www.omdbapi.com/?s=${query}&apikey=${API_KEY}`
  );

  const data = await response.json();

  if (data.Response === "False") return [];

  return data.Search?.slice(0, 3) || [];
};
