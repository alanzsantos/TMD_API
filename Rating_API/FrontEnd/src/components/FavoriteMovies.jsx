import React, { useEffect, useState } from 'react';
import axios from 'axios';

const FavoriteMovies = ({ userId, onSelectMovie }) => {
    const [favorites, setFavorites] = useState([]);
    const [searchTerm, setSearchTerm] = useState('');
    const [error, setError] = useState('');

    const fetchFavoriteMovies = async () => {
        try {
            const response = await axios.get(`${process.env.REACT_APP_API_FILME_FAVORITOS}/${userId}`);

            if (response.data?.$values) {
                setFavorites(response.data.$values.map(item => item.filme));
            } else {
                setFavorites([]);
            }
        } catch (error) {
            setError('Erro ao buscar filmes favoritos.');
        }
    };

    useEffect(() => {
        fetchFavoriteMovies();
    }, [userId]);

    const removeFromFavorites = async (movieId) => {
        try {
            await axios.delete(`${process.env.REACT_APP_API_FILME_FAVORITOS}/${movieId}/${userId}`);
            alert("O filme foi removido da lista de favoritos!");

            fetchFavoriteMovies();
        } catch (error) {
            setError('Erro ao remover filme dos favoritos.');
        }
    };

    const handleUpdateFavorites = () => {
        fetchFavoriteMovies();
    };

    const shareFavorites = async () => {
        try {
            if (favorites.length === 0) {
                alert('Nenhum favorito para compartilhar.');
                return;
            }

            const response = await axios.get(`${process.env.REACT_APP_API_FILME_COMPARTILHAR}/${userId}`);
            const shareLink = response.data.link;
            alert(`Compartilhe seus favoritos através deste link: ${shareLink}`);
        } catch (error) {
            setError('Erro ao gerar link de compartilhamento.');
        }
    };


    const filteredMovies = favorites.filter(favorite =>
        favorite.title.toLowerCase().includes(searchTerm.toLowerCase())
    );

    return (
        <div className="favorite-movies-container">
            <input
                type="text"
                placeholder="Pesquisar favoritos..."
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
                className="search-input"
            />
            <button onClick={shareFavorites} className="share-button">Compartilhar Favoritos</button>
            <button onClick={handleUpdateFavorites} className="update-button">Atualizar Lista</button>
            {error && <p className="error-message">{error}</p>}
            <table className="favorite-movies-table">
                <thead>
                    <tr>
                        <th>Título</th>
                        <th>Visão Geral</th>
                        <th>Nota</th>
                        <th>Pôster</th>
                        <th>Ações</th>
                    </tr>
                </thead>
                <tbody>
                    {filteredMovies.length > 0 ? (
                        filteredMovies.map((favorite) => (
                            <tr key={favorite.id}>
                                <td>{favorite.title}</td>
                                <td>{favorite.overview}</td>
                                <td style={{ fontWeight: 'bold', color: '#FF5733', fontSize: 30 }}>{favorite.rating}</td>
                                <td><img src={`https://image.tmdb.org/t/p/w500/${favorite.posterPath}`} alt={favorite.title} width="100" /></td>
                                <td>
                                    <button onClick={() => removeFromFavorites(favorite.id)} className="remove-button">Remover dos Favoritos</button>
                                </td>
                            </tr>
                        ))
                    ) : (
                        <tr>
                            <td colSpan="5">Nenhum filme favorito foi encontrado.</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    );
};

export default FavoriteMovies;

