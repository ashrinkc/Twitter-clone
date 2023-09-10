import SearchIcon from "@mui/icons-material/Search";
import axios from "axios";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { api } from "../config/data";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../redux/store";
import { changeRefresh } from "../redux/historySlice";
const SearchInput = () => {
  const [val, setVal] = useState("");
  const navigate = useNavigate();
  const user = useSelector((state: RootState) => state.auth.currentUser);
  const dispatch = useDispatch<AppDispatch>();

  const handleKeyDown = async (e: React.KeyboardEvent<HTMLInputElement>) => {
    if (e.key === "Enter") {
      if (val === "") {
        return;
      }
      const data = {
        userId: user.id,
        search: val,
      };
      const res = await axios.post(`${api}/History`, data);
      console.log(res.data);
      setVal("");
      await dispatch(changeRefresh());
      navigate("/explore", { state: { data: val } });
    }
  };

  return (
    <div className="bg-gray-100 rounded-2xl flex gap-3 p-2">
      <SearchIcon />
      <input
        className="bg-gray-100 focus:outline-none"
        placeholder="Search Twitter"
        value={val}
        onChange={(e) => setVal(e.target.value)}
        onKeyDown={handleKeyDown}
      />
    </div>
  );
};

export default SearchInput;
