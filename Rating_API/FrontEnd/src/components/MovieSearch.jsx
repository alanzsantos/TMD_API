import React, { useState } from 'react';
import axios from 'axios';

const MovieSearch = ({ onAddToFavorites }) => {
    const [searchTerm, setSearchTerm] = useState('');
    const [movies, setMovies] = useState([]);
    const [userId, setUserId] = useState('');
    const [error, setError] = useState('');

    const searchMovies = async () => {
        if (!userId) {
            setError('Por favor, insira o ID de usuário antes de buscar filmes.');
            return;
        }

        try {
            const response = await axios.get(`${process.env.REACT_APP_API_FILME_SEARCH}?consulta=${searchTerm}`);
            if (response.data?.$values) {
                setMovies(response.data.$values);
            } else {
                setMovies([]);
            }
        } catch (error) {
            setError('Por favor, informe o nome do filme desejado.');
        }
    };

    const handleAddToFavorites = async (movieId) => {
        if (!userId) {
            setError('Por favor, insira o ID de usuário antes de adicionar aos favoritos.');
            return;
        }

        try {
            await axios.post(`${process.env.REACT_APP_API_FILME_FAVORITOS}`, {
                movieId,
                userId
            }, {
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            alert('O filme foi adicionado aos favoritos com sucesso!');
        } catch (error) {
            alert('Esse filme já foi adicionado na sua lista de favoritos!');
        }
    };

    return (
        <div className="movie-search-container">
            <div className="search-controls">
                <input
                    type="text"
                    placeholder="Pesquisar filmes..."
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                    className="search-input"
                />
                <button onClick={searchMovies} className="search-button">Buscar</button>

                <input
                    type="text"
                    placeholder="Informe o UserId"
                    value={userId}
                    onChange={(e) => setUserId(e.target.value)}
                    className="user-id-input"
                />
                <button onClick={searchMovies} className="search-button">Pesquisar ID</button>
            </div>

            {error && <p className="error-message">{error}</p>}
            <ul className="movie-list">
                {movies.map((movie) => (
                    <li key={movie.id} className="movie-item">
                        <h3>{movie.title}</h3>
                        <p>{movie.overview}</p>                                                
                        <div className="rating-container">
                            <p className="rating">
                                Nota: {movie.rating}
                            </p>
                        </div>
                        <img src={`https://image.tmdb.org/t/p/w500/${movie.posterPath}`} alt={movie.title} width="100" />
                        <button onClick={() => handleAddToFavorites(movie.id)} className="add-button">Adicionar aos Favoritos</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default MovieSearch;
   