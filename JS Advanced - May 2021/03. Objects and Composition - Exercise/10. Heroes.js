function solve() {
    function decorateFight(state) {
        state.fight = () => {
            state.stamina--;
            console.log(`${state.name} slashes at the foe!`);
        }
    }

    function decorateCast(state) {
        state.cast = (spell) => {
            state.mana--;
            console.log(`${state.name} cast ${spell}`);
        }
    }    
    
    function fighter(name) {
        let fighterState = {
            name,
            health: 100,
            stamina: 100
        }
        
        decorateFight(fighterState);
        
        return fighterState;
    }
    
    function mage(name) {
        let mageState = {
            name,
            health: 100,
            stamina: 100
        }
        
        decorateCast(mageState);
        
        return mageState;
    }
    
    return { fighter, mage };
}
