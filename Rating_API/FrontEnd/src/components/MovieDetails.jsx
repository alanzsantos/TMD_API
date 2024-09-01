import React, { useEffect, useState } from 'react';
import axios from 'axios';

const MovieDetails = ({ movieId }) => {
    const [movie, setMovie] = useState(null);
    const [error, setError] = useState('');

    useEffect(() => {
        const fetchMovieDetails = async () => {
            try {
                const response = await axios.get(`${process.env.REACT_APP_API_FILME_BY_ID}/${movieId}`);
                if (response.data) {
                    setMovie(response.data);
                }
            } catch (error) {
                setError('Erro ao buscar detalhes do filme.');
            }
        };

        if (movieId) {
            fetchMovieDetails();
        }
    }, [movieId]);

    if (!movieId) {
        return null;
    }

    return (
        <div className="movie-details-container">
            {error && <p className="error-message">{error}</p>}
            {movie ? (
                <div className="movie-details">
                    <h2>{movie.title}</h2>
                    <img src={`https://image.tmdb.org/t/p/w500/${movie.posterPath}`} alt={movie.title} width="300" />
                    <p><strong>Visão Geral:</strong> {movie.overview}</p>
                    <p><strong>Nota:</strong> {movie.rating}</p>
                </div>
            ) : null}
        </div>
    );
};

export default MovieDetails;  