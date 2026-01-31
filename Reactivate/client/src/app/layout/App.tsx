import { Box, Container, CssBaseline } from "@mui/material"
import NavBar from "./NavBar"
import GimmicksDashboard from "../../features/gimmicks/dashboard/GimmicksDashboard"
import axios from "axios"
import { useEffect, useState } from "react"

function App() {
  const [gimmicks, setGimmicks] = useState<Gimmick[]>([])
  const [selectedGimmick, setSelectedGimmick] = useState<Gimmick | undefined>(undefined)

  const handleSelectGimmick = (id: string) => {
    setSelectedGimmick(gimmicks.find(x => x.id === id));
  }

  const handleCancelSelect = () => {
    setSelectedGimmick(undefined);
  }

  const deleteGimmick = (id: string) => {
    setGimmicks(gimmicks.filter(g => g.id !== id))
  }

  useEffect(() => {
    axios.get<Gimmick[]>("https://localhost:5001/api/gimmicks")
      .then(response => setGimmicks(response.data))
  }, [])

  return (
    <>
      <Box sx={{ bgcolor: '#eeeeee', minHeight: '100vh' }}>
        <CssBaseline />
        <NavBar />
        <Container maxWidth='xl' sx={{ mt: 3 }}>
          <GimmicksDashboard
            gimmicks={gimmicks}
            selectedGimmick={selectedGimmick}
            selectGimmick={handleSelectGimmick}
            cancelSelect={handleCancelSelect}
            deleteGimmick={deleteGimmick}

          />
        </Container>

      </Box>
    </>

  )
}

export default App
