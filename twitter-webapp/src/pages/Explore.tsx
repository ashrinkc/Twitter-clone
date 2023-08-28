import { api, explorePost } from "../config/data";
import Posts from "../components/Posts";
import People, { IUserE } from "../components/People";
import { useEffect, useState } from "react";
import axios from "axios";
import { useLocation } from "react-router-dom";

const Explore = () => {
  const [users, setUsers] = useState([]);
  const [filteredUsers, setFilteredUsers] = useState([]);
  const val = useLocation().state?.data;
  useEffect(() => {
    const getAllUsers = async () => {
      try {
        const res = await axios.get(`${api}/user`);
        setUsers(res.data);
        if (val && val !== "") {
          const res = users.filter((u: IUserE) => u?.username.startsWith(val));
          setFilteredUsers(res);
        } else {
          console.log(users);
          setFilteredUsers(res.data);
        }
      } catch (err) {
        console.log(err);
      }
    };

    getAllUsers();
  }, [val]);

  return (
    <div>
      <h1 className="font-bold text-3xl">Explore</h1>
      <hr className="mt-5" />
      <div className="mt-2 flex flex-col gap-3">
        {filteredUsers?.map((data: IUserE) => (
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
