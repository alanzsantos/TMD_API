import React, { useState } from 'react';
import FavoriteMovies from './components/FavoriteMovies';
import MovieSearch from './components/MovieSearch';
import MovieDetails from './components/MovieDetails';
import axios from 'axios';
import './App.css';

const App = () => {
    const [selectedMovieId, setSelectedMovieId] = useState(null);
    const userId = process.env.REACT_APP_USER_ID;

    const addToFavorites = async (movieId) => {
        try {
            await axios.post(`${process.env.REACT_APP_API_FILME_FAVORITOS}`, { movieId, userId });
            alert('Filme adicionado aos favoritos!');
        } catch (error) {
            alert('Erro ao adicionar o filme aos favoritos.');
        }
    };

    return (
        <div className="app-container">
            <h1>Lista de Filmes</h1>
            <MovieSearch onAddToFavorites={addToFavorites} />
            <FavoriteMovies userId={userId} onSelectMovie={setSelectedMovieId} />
            {selectedMovieId && <MovieDetails movieId={selectedMovieId} />}
        </div>
    );
};

export default App;