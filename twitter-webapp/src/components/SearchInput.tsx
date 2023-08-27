import SearchIcon from "@mui/icons-material/Search";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
const SearchInput = () => {
  const [val, setVal] = useState("");
  const navigate = useNavigate();
  const handleKeyDown = (e: React.KeyboardEvent<HTMLInputElement>) => {
    if (e.key === "Enter") {
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
