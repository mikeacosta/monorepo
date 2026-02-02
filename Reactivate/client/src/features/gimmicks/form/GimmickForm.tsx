import { Box, Button, Paper, TextField, Typography } from "@mui/material"

type Props = {
  gimmick?: Gimmick
  closeForm: () => void
}

const GimmickForm = ({ closeForm, gimmick }: Props) => {
  return (
    <Paper sx={{ borderRadius: 3, padding: 3 }}>
      <Typography variant="h5" gutterBottom color="primary">
        Create gimmick
      </Typography>  
      <Box component='form' display='flex' flexDirection='column' gap={3}>
        <TextField name='title' label='Title' defaultValue={gimmick?.title || ''} />
        <TextField name='description' label='Description' defaultValue={gimmick?.category || ''} multiline rows={3} />
        <TextField name='category' defaultValue={gimmick?.category || ''} label='Category' />
        <TextField name='date' defaultValue={gimmick?.date ? new Date(gimmick.date).toISOString().split('T')[0] : ''} label='Date' type="date" />
        <TextField name='city' defaultValue={gimmick?.city || ''} label='City' />
        <TextField name='venue' defaultValue={gimmick?.venue || ''} label='Venue' />
        <Box display='flex' justifyContent='end' gap={3}>
          <Button onClick={closeForm} color='inherit'>Cancel</Button>
          <Button type="submit" color='success' variant="contained">Submit</Button>
        </Box>
      </Box>          
    </Paper>
  )
}
export default GimmickForm