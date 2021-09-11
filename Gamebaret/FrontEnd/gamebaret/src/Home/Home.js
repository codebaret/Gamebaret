import Games from "./Components/Games/Games";
import { fetchTags,fetchCategories } from "../state/action-creator/games";
import { useDispatch } from 'react-redux';
import {useEffect, useState} from 'react';

function Home() {
    const dispatch = useDispatch()
    const [tags, setTags] = useState([])
    const [categories, setCategories] = useState([])
    useEffect(() => {
         dispatch(fetchTags()).then(res => setTags(res.data)).catch(err => console.log(err))
         dispatch(fetchCategories()).then(res => setCategories(res.data)).catch(err => console.log(err))
    }, [dispatch])

    return (
        <Games tags={tags} categories={categories} />
    );
}
export default Home;  