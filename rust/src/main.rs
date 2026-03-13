use std::{env, fs};
mod day_one;

fn main() {
    let args: Vec<String> = env::args().collect();
    let path = &args[1];
    let input = fs::read_to_string(path).expect("Should have been able to read the file");

    day_one::run(input, 50);
}

mod tests {

    #[test]
    fn can_read_input_argument() {}
}
