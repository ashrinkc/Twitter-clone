import { api, explorePost } from "../config/data";
import Posts from "../components/Posts";
import People, { IUserE } from "../components/People";
import { useEffect, useState } from "react";
import axios from "axios";

const Explore = () => {
  const [users, setUsers] = useState([]);
  useEffect(() => {
    const getAllUsers = async () => {
      const res = await axios.get(`${api}/user`);
      setUsers(res.data);
    };
    getAllUsers();
  }, []);
  return (
    <div>
      <h1 className="font-bold text-3xl">Explore</h1>
      <hr className="mt-5" />
      <div className="mt-2 flex flex-col gap-3">
        {users.map((data: IUserE) => (
          <People
            id={data.id}
            username={data.username}
            email={data.email}
            joinDate={data.joinDate}
            image={data.image}
          />
        ))}
        {/* {explorePost.map((data) => (
          <Posts
            profileImg={data.profileImg}
            desc={data.desc}
            postImg={data.postImg}
            name={data.name}
            username={data.username}
          />
        ))} */}
      </div>
    </div>
  );
};

export default Explore;
