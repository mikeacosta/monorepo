
import { Grid } from "@mui/material"
import GimmicksList from "./GimmicksList"
import GimmickDetails from "../details/GimmickDetails"

type Props = {  
  gimmicks: Gimmick[]
  selectedGimmick: Gimmick | undefined
  selectGimmick: (id: string) => void 
  cancelSelect: () => void
  deleteGimmick: (id: string) => void
}

const GimmicksDashboard = ({ gimmicks, selectedGimmick, selectGimmick, cancelSelect, deleteGimmick }: Props) => {
  return (
    <Grid container spacing={3}>
      <Grid size={7}>
        <GimmicksList 
          gimmicks={gimmicks} 
          selectGimmick={selectGimmick}
          deleteGimmick={deleteGimmick}
        />
      </Grid>
      <Grid size={5}>
        {selectedGimmick && 
        <GimmickDetails 
          gimmick={selectedGimmick}
          cancelSelect={cancelSelect}
        />}
      </Grid>
    </Grid>
  )
}

export default GimmicksDashboard