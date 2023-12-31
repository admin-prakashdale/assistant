import { Button, Checkbox, makeStyles, shorthands, Title1, tokens } from '@fluentui/react-components';
import type { NextPage } from 'next';
import Head from 'next/head';

const useStyles = makeStyles({
  container: {
    display: 'flex',
    flexDirection: 'column',
    width: '200px',

    ...shorthands.border('2px', 'dashed', tokens.colorPaletteBerryBorder2),
    ...shorthands.borderRadius(tokens.borderRadiusMedium),
    ...shorthands.gap('5px'),
    ...shorthands.padding('10px'),
  },
});

const Home: NextPage = () => {
  const styles = useStyles();

  return (
    <>
      <Head>
        <title>My app</title>
      </Head>

      <div className={styles.container}>
        <Title1>Hello world!</Title1>
        <Checkbox label='I agree to terms and conditions'></Checkbox>
        <Button>A button</Button>
      </div>
    </>
  );
};

export default Home;